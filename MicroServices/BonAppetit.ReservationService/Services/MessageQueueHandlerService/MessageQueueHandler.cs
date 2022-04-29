using AutoMapper;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Models.MessageQueueModels.PaymentSuccessMessageModels;
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

    public async Task<ReservationDto> PaymentSuccessMessageHandlerAsync(PaymentSuccessMessage paymentSuccess, CancellationToken cancellationToken)
    {
        using var scope = _scopeFactory.CreateScope();
        var _mapper = scope.ServiceProvider.GetRequiredService<IMapper>();
        var _db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        var reservationToMake = paymentSuccess.ReservationCreate;

        var reservationT = _mapper.Map<ReservationBase>(reservationToMake);

        if (string.IsNullOrEmpty(reservationToMake.ApplicationUserId))
            reservationT.IsUserAnonymous = true;

        var isAlreadyReserved = await _db.Reservations.Where(
            rsvp => rsvp.TableId == reservationT.TableId
                    && rsvp.StartTime == reservationT.StartTime).ToListAsync(cancellationToken);

        if (isAlreadyReserved.Any())
        {
            _logger.Log(LogLevel.Critical,"The Table is already reserved for the time requested");
            return null!;
        }

        var entity = await _db.Reservations.AddAsync(reservationT, cancellationToken);

        if (entity.State != EntityState.Added)
        {
            _logger.Log(LogLevel.Critical,"Could not add the reservation");
            return null!;
        }

        try
        {
            await _db.SaveChangesAsync(cancellationToken);
        }
        catch (DbUpdateException e)
        {
            _logger.Log(LogLevel.Critical, $"Could not save the reservation: Error message {e.Message}, inner exception {e.InnerException.Message}");
            return null!;
        }

        _logger.Log(LogLevel.Information, $"Reservation made successfully, {reservationT.ReservationId}");
        var reservationDto = _mapper.Map<ReservationDto>(reservationT);
        return reservationDto;
    }
}