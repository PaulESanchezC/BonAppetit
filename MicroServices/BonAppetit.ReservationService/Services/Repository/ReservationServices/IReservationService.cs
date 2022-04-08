using Models.ReservationModels;
using Models.ResponseModels;

namespace Services.Repository.ReservationServices;

public interface IReservationService : IRepository<ReservationBase, ReservationDto, ReservationCreate>
{
    Task<Response<ReservationDto>> MakeReservationAsync(ReservationCreate reservationToMake,
        CancellationToken cancellationToken);
}