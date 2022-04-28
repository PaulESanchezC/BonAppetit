using Stripe.Checkout;
using AutoMapper;
using Data;
using Microsoft.EntityFrameworkCore;
using Models.PaymentMessageModels;
using Models.PaymentModels;
using Models.ResponseModels;
using Services.RabbitMqSender;
using StaticData;


namespace Services.PaymentServices;

public class PaymentServices : IPaymentServices
{
    private readonly ApplicationDbContext _db;
    private readonly IMapper _mapper;
    private readonly IPaymentMessageSender _paymentMessageSender;
    public PaymentServices(ApplicationDbContext db, IMapper mapper, IPaymentMessageSender paymentMessageSender)
    {
        _db = db;
        _mapper = mapper;
        _paymentMessageSender = paymentMessageSender;
    }

    public async Task<Response<PaymentDto>> CreateStripePaymentSessionAsync(PaymentCreate paymentInformation, CancellationToken cancellationToken)
    {
        var amount = 20 * paymentInformation.TableSeats;
        var options = new SessionCreateOptions
        {
            PaymentMethodTypes = new List<string>
            {
                "card"
            },
            LineItems = new List<SessionLineItemOptions>
            {
                new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        UnitAmount = amount*100,
                        Currency="CAD",
                        ProductData= new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = $"Reservation in {paymentInformation.RestaurantName} for, {paymentInformation.TableSeats}"
                        }
                    },
                    Quantity=1
                }
            },
            Mode = "payment",
            SuccessUrl = "https://localhost:44343//ReservationConfirmed",
            CancelUrl = $"https://localhost:44343//RestaurantDetails/{paymentInformation.RestaurantId}"
        };

        var service = new SessionService();
        var session = await service.CreateAsync(options, cancellationToken: cancellationToken);

        if (session is null)
            return new Response<PaymentDto>
            {
                IsSuccessful = false,
                StatusCode = 400,
                Title = "Error",
                Message = "Could not create Session",
                ResponseObject = null
            };

        var paymentOrder = _mapper.Map<PaymentBase>(paymentInformation);

        paymentOrder.IsPayed = false;
        paymentOrder.Amount = amount;
        paymentOrder.ReservationId = "Pending Payment";
        var entity = await _db.Payments.AddAsync(paymentOrder, cancellationToken);

        if (entity.State != EntityState.Added)
            return new Response<PaymentDto>
            {
                IsSuccessful = false,
                StatusCode = 400,
                Title = "Error",
                Message = "Could not create payment order",
                ResponseObject = null
            };

        try
        {
            await _db.SaveChangesAsync(cancellationToken);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new Response<PaymentDto>
            {
                IsSuccessful = false,
                StatusCode = 400,
                Title = "Error",
                Message = "Could not Save payment order",
                ResponseObject = null
            };
        }

        var paymentDto = _mapper.Map<PaymentDto>(paymentOrder);
        paymentDto.PaymentSessionId = session.Id;
        return new Response<PaymentDto>
        {
            IsSuccessful = true,
            StatusCode = 201,
            Title = "Ok",
            Message = "Ok",
            ResponseObject = new() { paymentDto }
        };
    }

    public async Task<Response<PaymentDto>> ConfirmPaymentIsSuccessful(PaymentDto paymentToConfirm, CancellationToken cancellationToken)
    {
        var service = new SessionService();
        var sessionDetails = await service.GetAsync(paymentToConfirm.PaymentSessionId, cancellationToken: cancellationToken);
        if (sessionDetails.PaymentStatus is not "paid")
            return new Response<PaymentDto>
            {
                IsSuccessful = false,
                StatusCode = 400,
                Title = "Error",
                Message = "The reservation has not been paid",
                ResponseObject = null
            };

        var payment = await _db.Payments.FirstOrDefaultAsync(payment =>payment.PaymentId == paymentToConfirm.PaymentId, cancellationToken);
        if (payment is null)
            return new Response<PaymentDto>
            {
                IsSuccessful = false,
                StatusCode = 400,
                Title = "Error",
                Message = "Could not find payment order",
                ResponseObject = null
            };

        payment.IsPayed = true;
        payment.DateOfPayment = DateTime.Now;


        var entity = _db.Payments.Update(payment!);
        if (entity.State != EntityState.Modified)
        {
            return new Response<PaymentDto>
            {
                IsSuccessful = false,
                StatusCode = 400,
                Title = "Error",
                Message = "Could not update payment status",
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
                Message = "Could not save updated payment order",
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

        var paymentMessage = new PaymentMessage { Message = response };
        _paymentMessageSender.SendMessage(paymentMessage, RabbitMqConstants.QueueName);

        return response;
    }
}