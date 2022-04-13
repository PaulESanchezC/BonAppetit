using Stripe.Checkout;
using AutoMapper;
using Data;
using Microsoft.EntityFrameworkCore;
using Models.PaymentModels;
using Models.ResponseModels;

namespace Services.PaymentServices;

public class PaymentServices : IPaymentServices
{
    private readonly ApplicationDbContext _db;
    private readonly IMapper _mapper;
    public PaymentServices(ApplicationDbContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<Response<PaymentDto>> CreateStripePaymentSessionAsync(PaymentCreate paymentInformation, CancellationToken cancellationToken)
    {
        var options = new SessionCreateOptions
        {
            PaymentMethodTypes = new List<string>
            {
                "Cards", "Wallets"
            },
            LineItems = new List<SessionLineItemOptions>
            {
                new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {

                        UnitAmount = paymentInformation.Amount,
                        Currency="CAD",
                        ProductData= new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = $"Reservation in {paymentInformation.RestaurantName} for {paymentInformation.ReservationFor}"
                        }
                    },
                    Quantity=1
                }
            },
            Mode = "payment",
            SuccessUrl = $"https://localhost:44343//ReservationConfirmed?session_id={{CHECKOUT_SESSION_ID}}",
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
                ResponseObject = {paymentDto}
            };
    }

    public async Task<Response<PaymentDto>> ConfirmPaymentIsSuccessful(PaymentDto paymentToConfirm, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}