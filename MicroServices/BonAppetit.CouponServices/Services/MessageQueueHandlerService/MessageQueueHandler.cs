using AutoMapper;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Models.CouponActivity;
using Models.MessageQueueModels.ReservationSuccessModels;
using Models.ReservationModels;


namespace Services.MessageQueueHandlerService;

public class MessageQueueHandler : IMessageQueueHandler
{
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly ILogger<MessageQueueHandler> _logger;
    public MessageQueueHandler(IServiceScopeFactory scopeFactory, ILogger<MessageQueueHandler> logger)
    {
        _scopeFactory = scopeFactory;
        _logger = logger;
    }

    public async Task ReservationSuccessMessageHandlerAsync(ReservationSuccessMessage reservationSuccessMessage, CancellationToken cancellationToken)
    {
        using var scope = _scopeFactory.CreateScope();
        var _mapper = scope.ServiceProvider.GetRequiredService<IMapper>();
        var _db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        reservationSuccessMessage.CouponsCodes.ForEach( coupon =>
        {
            var couponActivity = new CouponActivity
            {
                RestaurantId = reservationSuccessMessage.RestaurantId,
                CouponCode = coupon,
                DateCreated = DateTime.Now,
                ApplicationUserId = reservationSuccessMessage.ApplicationUserId
            };

            var entity = _db.CouponActivities.AddAsync(couponActivity, cancellationToken).GetAwaiter().GetResult();
            if (entity.State != EntityState.Added)
                _logger.Log(LogLevel.Critical, "Could not add the coupon activity");

            try
            {
                _db.SaveChangesAsync(cancellationToken).GetAwaiter().GetResult();
            }
            catch (DbUpdateException e)
            {
                _logger.Log(LogLevel.Critical, $"Could not save the coupon activity: Error message {e.Message}, inner exception {e.InnerException.Message}");
            }

            _logger.Log(LogLevel.Information, $"Coupon activity made successfully, {couponActivity.CouponActivityId}");
        });
    }
}