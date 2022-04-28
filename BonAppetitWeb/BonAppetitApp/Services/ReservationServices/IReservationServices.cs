using Models.ReservationModels;
using Models.ResponseModels;

namespace Services.ReservationServices;

public interface IReservationServices
{
    Task<Response<Reservation>> MakeReservationAsync(ReservationCreate reservationToMake);
}