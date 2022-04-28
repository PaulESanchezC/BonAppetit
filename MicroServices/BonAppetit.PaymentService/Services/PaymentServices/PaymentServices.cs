using Stripe.Checkout;
using AutoMapper;
using Data;
using Microsoft.EntityFrameworkCore;
using Models.PaymentMessageModels;
using Models.PaymentModels;
using Models.ResponseModels;
using Models.StripeSessionModels;
using Services.RabbitMqSender;
using StaticData;
using Stripe;


namespace Services.PaymentServices;

public class PaymentServices : IPaymentServices
{
    private readonly ApplicationDbContext _db;
    private readonly IMapper _mapper;
    private readonly IPaymentMessageSender _paymentMessageSender;
    public string GstTaxId { get; set; }
    public string PstTaxId { get; set; }

    public PaymentServices(ApplicationDbContext db, IMapper mapper, IPaymentMessageSender paymentMessageSender)
    {
        _db = db;
        _mapper = mapper;
        _paymentMessageSender = paymentMessageSender;
    }

    public async Task<Response<StripeSession>> CreateStripePaymentSessionAsync(StripeSessionCreate paymentInformation, CancellationToken cancellationToken)
    {
        await CreateTaxesOptionsAsync(cancellationToken);
        var bonAppetitFee = 30;

        var options = new SessionCreateOptions
        {

            PaymentMethodTypes = new List<string>
            {
                "card"
            },
            LineItems = new List<SessionLineItemOptions>
            {
                new()
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        UnitAmount = (long)paymentInformation.RestaurantReservationFee,
                        Currency="CAD",
                        ProductData= new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = $"Reservation in {paymentInformation.RestaurantName} for, {paymentInformation.TableSeats}",
                            Description = "Restaurant reservation fee"
                        },
                        TaxBehavior = "exclusive"
                    },
                    Quantity = paymentInformation.TableSeats,
                    TaxRates = new(){PstTaxId,GstTaxId}
                },
                new()
                {
                    PriceData = new SessionLineItemPriceDataOptions()
                    {
                        UnitAmount = bonAppetitFee,
                        Currency = "CAD",
                        Product = "Bon Appetit App Reservation fee",
                        TaxBehavior = "exclusive"
                    },
                    Quantity = 1,
                    TaxRates = new(){PstTaxId,GstTaxId}
                }
            },
            AutomaticTax = new SessionAutomaticTaxOptions()
            {
                Enabled = true
            },
            Mode = "payment",
            SuccessUrl = "https://localhost:44343//ReservationConfirmed",
            CancelUrl = $"https://localhost:44343//RestaurantDetails/{paymentInformation.RestaurantId}"
        };

        var service = new SessionService();
        var session = await service.CreateAsync(options, cancellationToken: cancellationToken);

        if (session is null)
            return new Response<StripeSession>
            {
                IsSuccessful = false,
                StatusCode = 400,
                Title = "Error",
                Message = "Could not create Session",
                ResponseObject = null
            };

        var stripeSession = await Task.FromResult(BuildStripeSessionModel(session.Id,bonAppetitFee,paymentInformation.RestaurantReservationFee,paymentInformation.TableSeats));

        return new Response<StripeSession>
        {
            IsSuccessful = true,
            StatusCode = 200,
            Title = "Ok",
            Message = "Ok",
            ResponseObject = new(){ stripeSession }
        };
    }

    public async Task<Response<PaymentDto>> ConfirmPaymentIsSuccessful(PaymentCreate paymentToConfirm, PaymentMessage message, CancellationToken cancellationToken)
    {
        var service = new SessionService();
        var sessionDetails = await service.GetAsync(paymentToConfirm.SessionId, cancellationToken: cancellationToken);
        if (sessionDetails.PaymentStatus is not "paid")
            return new Response<PaymentDto>
            {
                IsSuccessful = false,
                StatusCode = 400,
                Title = "Error",
                Message = "The reservation has not been paid",
                ResponseObject = null
            };

        var payment = _mapper.Map<PaymentBase>(paymentToConfirm);

        var entity = await _db.Payments.AddAsync(payment,cancellationToken);

        if (entity.State != EntityState.Added)
        {
            return new Response<PaymentDto>
            {
                IsSuccessful = false,
                StatusCode = 400,
                Title = "Error",
                Message = "Could not add payment status",
                ResponseObject = null
            };
        }

        try
        {
            await _db.SaveChangesAsync(cancellationToken);
        }
        catch (DbUpdateException e)
        {
            Console.WriteLine(e);
            return new Response<PaymentDto>
            {
                IsSuccessful = false,
                StatusCode = 400,
                Title = "Error",
                Message = "Could not save payment order",
                ResponseObject = null
            };
        }

        var paymentDto = _mapper.Map<PaymentDto>(payment);

        var response = new Response<PaymentDto>
        {
            IsSuccessful = true,
            StatusCode = 200,
            Title = "Ok",
            Message = "Ok",
            ResponseObject = new() { paymentDto }
        };

        message.ReservationCreate.PaymentTransaction = paymentDto.PaymentId;
        var successMessage = _mapper.Map<PaymentSuccessMessage>(message);
        successMessage.Payment = paymentDto;
        _paymentMessageSender.SendMessage(successMessage, RabbitMqConstants.QueueName);

        return response;
    }

    public async Task<Response<PaymentDto>> GetPaymentInformation(string paymentId, CancellationToken cancellationToken)
    {
        var payment = await _db.Payments.Where(payment => payment.PaymentId == paymentId)
            .FirstOrDefaultAsync(cancellationToken);

        if (payment is null)
            return new Response<PaymentDto>
            {
                IsSuccessful = false,
                StatusCode = 400,
                Title = "Error",
                Message = "Could not find payment order",
                ResponseObject = null
            };

        var paymentDto = _mapper.Map<PaymentDto>(payment);

        return new Response<PaymentDto>
        {
            IsSuccessful = true,
            StatusCode = 200,
            Title = "Ok",
            Message = "Ok",
            ResponseObject = new() { paymentDto }
        };
    }

    #region Helper Methods

    private async Task CreateTaxesOptionsAsync(CancellationToken cancellationToken)
    {
        var pstTaxOptions = new TaxRateCreateOptions
        {
            DisplayName = "PST",
            Inclusive = false,
            Percentage = 9.975m,
            Country = "CA",
            State = "QC",
            Description = "Provincial Sales Tax",
        };

        var gstTaxOptions = new TaxRateCreateOptions
        {
            DisplayName = "GST",
            Inclusive = false,
            Percentage = 5,
            Country = "CA",
            Description = "Goods and Services Taxes",
        };
        var pstTaxService = new TaxRateService();
        var pstTax = await pstTaxService.CreateAsync(pstTaxOptions, cancellationToken: cancellationToken);

        var gstTaxService = new TaxRateService();
        var gstTax = await gstTaxService.CreateAsync(pstTaxOptions, cancellationToken: cancellationToken);

        PstTaxId = pstTax.Id;
        GstTaxId = gstTax.Id;
    }
    private StripeSession BuildStripeSessionModel(string sessionId, double restaurantFee, double bonAppetitFee, int tableSeats)
    {
        var amount = tableSeats * restaurantFee + bonAppetitFee;

        var pst = amount * 0.09975;
        var gst = amount * 0.05;

        var total = amount + pst + gst;

        return new StripeSession
        {
            SessionId = sessionId,
            RestaurantFee = restaurantFee,
            BonAppetitFee = bonAppetitFee,
            ProvincialTaxes = pst,
            FederalTaxes = gst,
            Amount = total
        };
    }

    #endregion
}