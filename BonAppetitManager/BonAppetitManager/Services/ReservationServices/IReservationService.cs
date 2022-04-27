using Models.ReservationModels;
using Models.ResponseModels;

namespace Services.ReservationServices;

public interface IReservationService
{
    Task<Response<Reservation>> GetReservationsAsync();
    Task<Response<Reservation>> FindReservationsAsync();
}