using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Models.MessageQueueModels.PaymentSuccessMessageModels;
using Models.ReservationModels;


namespace Services.MessageQueueHandlerService;

public class MessageQueueHandler : IMessageQueueHandler
{
    private readonly IServiceScopeFactory scopeFactory;

    public MessageQueueHandler(IServiceScopeFactory scopeFactory)
    {
        this.scopeFactory = scopeFactory;
    }

    public async Task PaymentSuccessMessageHandlerAsync(PaymentSuccessMessage paymentSuccess, CancellationToken cancellationToken)
    {
        using var scope = scopeFactory.CreateScope();
        var _db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        var reservationToMake = paymentSuccess.ReservationCreate;

        var reservationT = MapReservationCreateToReservationBase(reservationToMake);

        if (string.IsNullOrEmpty(reservationToMake.ApplicationUserId))
            reservationT.IsUserAnonymous = true;

        var isAlreadyReserved = await _db.Reservations.Where(
            rsvp => rsvp.TableId == reservationT.TableId
                    && rsvp.StartTime == reservationT.StartTime).ToListAsync(cancellationToken);

        if (isAlreadyReserved.Any())
        {
            Console.WriteLine("The Table is already reserved for the time requested");
            return;
        }

        var entity = await _db.Reservations.AddAsync(reservationT, cancellationToken);

        if (entity.State != EntityState.Added)
        {
            Console.WriteLine("Could not add the reservation");
            return;
        }

        try
        {
            await _db.SaveChangesAsync(cancellationToken);
        }
        catch (DbUpdateException e)
        {
            Console.WriteLine($"Could not save the reservation: Error message {e.Message}, inner exception {e.InnerException.Message}");
            return;
        }

        Console.WriteLine($"Reservation made successfully, {reservationT}");
    }


    #region Helper Methods

    private ReservationBase MapReservationCreateToReservationBase(ReservationCreate reservationCreate)
    {
        var reservation = new ReservationBase
        {
            StartTime = reservationCreate.StartTime,
            TableId = reservationCreate.TableId,
            DateOfReservation = reservationCreate.DateOfReservation,
            RestaurantId = reservationCreate.RestaurantId,
            ApplicationUserId = reservationCreate.ApplicationUserId,
            Email = reservationCreate.Email,
            FirstName = reservationCreate.FirstName,
            LastName = reservationCreate.LastName,
            Phone = reservationCreate.Phone,
            PaymentTransaction = reservationCreate.PaymentTransaction
        };
        return reservation;
    }

    #endregion
}