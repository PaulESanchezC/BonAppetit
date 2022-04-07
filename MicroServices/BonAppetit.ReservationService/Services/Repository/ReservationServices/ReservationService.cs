using AutoMapper;
using Data;
using Models.ReservationModels;

namespace Services.Repository.ReservationServices;

public class ReservationService : Repository<ReservationBase, ReservationDto>, IReservationService
{
    public ReservationService(ApplicationDbContext db, IMapper mapper) : base(db, mapper)
    {
    }
}