using Models.ReservationModels;

namespace Services.Repository.ReservationServices;

public interface IReservationService : IRepository<ReservationBase,ReservationDto>
{
}