using AutoMapper;
using Data;
using Microsoft.EntityFrameworkCore;
using Models.ReservationModels;
using Models.ResponseModels;

namespace Services.Repository.ReservationServices;

public class ReservationService : Repository<ReservationBase, ReservationDto, ReservationCreate>, IReservationService
{
    private readonly ApplicationDbContext _db;
    private readonly IMapper _mapper;

    public ReservationService(ApplicationDbContext db, IMapper mapper) : base(db, mapper)
    {
        _db = db;
        _mapper = mapper;
    }
    public async Task<Response<ReservationDto>> MakeReservationAsync(ReservationCreate reservationToMake, CancellationToken cancellationToken)
    {
        var reservationT = _mapper.Map<ReservationBase>(reservationToMake);

        if (string.IsNullOrEmpty(reservationToMake.ApplicationUserId))
            reservationT.IsUserAnonymous = true;

        var isAlreadyReserved = await _db.Reservations.Where(
            rsvp => rsvp.TableId == reservationT.TableId
                    && rsvp.StartTime == reservationT.StartTime).ToListAsync(cancellationToken);

        if (isAlreadyReserved.Any())
            return await ResponseSingleBuilderTask(false, 400, "Table Reserved",
                "The Table is already reserved for the time requested", null);

        var entity = await _db.Reservations.AddAsync(reservationT);

        if (entity.State != EntityState.Added)
            return await ResponseSingleBuilderTask(false, 409, "Operation Failed", $"Could not add the reservation", null);

        try
        {
            await _db.SaveChangesAsync(cancellationToken);
        }
        catch (DbUpdateException e)
        {
            return await ResponseSingleBuilderTask(false, 409, "Operation Failed", $"Could not save the reservation", null);
        }

        return await ResponseSingleBuilderTask(true, 201, "Ok", "Ok", reservationT);

    }
}