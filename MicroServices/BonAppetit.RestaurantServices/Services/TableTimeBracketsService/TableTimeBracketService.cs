using AutoMapper;
using Data;
using Microsoft.EntityFrameworkCore;
using Models.ReservationModels;
using Models.ResponseModels;
using Models.ScheduleModels;
using Models.TableModels;
using Models.TableReservationBracketsModels;
using Newtonsoft.Json;

namespace Services.TableTimeBracketsService;

public class TableTimeBracketService : ITableTimeBracketService
{
    private readonly ApplicationDbContext _db;
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IMapper _mapper;

    public TableTimeBracketService(ApplicationDbContext db, IHttpClientFactory httpClientFactory, IMapper mapper)
    {
        _db = db;
        _httpClientFactory = httpClientFactory;
        _mapper = mapper;
    }

    public async Task<Response<TableReservationBracketDto>> GetAllTableReservationBracketsForRestaurantAsync(
        string restaurantId, DateTime dateOfRequest, CancellationToken cancellationToken)
    {
        var tableReservationsRequest = await GetTableReservationsAsync(restaurantId, dateOfRequest, cancellationToken);
        if (!tableReservationsRequest.IsSuccessful)
            return new Response<TableReservationBracketDto>
            {
                IsSuccessful = tableReservationsRequest!.IsSuccessful,
                StatusCode = tableReservationsRequest.StatusCode,
                Title = tableReservationsRequest.Title,
                Message = tableReservationsRequest.Message,
                ResponseObject = null
            };
        var tableReservations = tableReservationsRequest.ResponseObject;

        var tables = await _db.Tables.Where(table => table.RestaurantId == restaurantId).ToListAsync(cancellationToken);
        if (!tables.Any())
            return new Response<TableReservationBracketDto>
            {
                IsSuccessful = false,
                StatusCode = 400,
                Title = "Empty Result",
                Message = "The operation returned an empty result",
                ResponseObject = null
            };

        var restaurant = await _db.Restaurants.Include(include => include.RestaurantSchedule)
            .FirstOrDefaultAsync(resto => resto.RestaurantId == restaurantId, cancellationToken);
        if (restaurant is null)
            return new Response<TableReservationBracketDto>
            {
                IsSuccessful = false,
                StatusCode = 400,
                Title = "Empty Result",
                Message = "The operation returned an empty result",
                ResponseObject = null
            };

        var restaurantSchedule = restaurant.RestaurantSchedule;
        var (openingHours, closingHours) = await GetDayOfTheWeekOpeningAndClosingHoursAsync(restaurantSchedule, dateOfRequest);
        var reservationsBracketsDto = await BuildTableReservationBracketDtoAsync(tables, tableReservations,openingHours, closingHours);

        return new Response<TableReservationBracketDto>
        {
            IsSuccessful = true,
            StatusCode = 200,
            Title = "Ok",
            Message = "Ok",
            ResponseObject = reservationsBracketsDto
        };
    }

    #region Helper Methods

    private async Task<Response<ReservationDto>> GetTableReservationsAsync(string restaurantId, DateTime dateOfRequest, CancellationToken cancellationToken)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, $"https://localhost:44314/api/Reservation/GetAllReservationsForRestaurantByDate/{restaurantId}/{dateOfRequest:MM-dd-yyyy}");
        var client = await _httpClientFactory.CreateClient().SendAsync(request, cancellationToken);
        var responseString = await client.Content.ReadAsStringAsync(cancellationToken);
        var reservationsResponse = JsonConvert.DeserializeObject<Response<ReservationDto>>(responseString);
        return reservationsResponse!;
    }

    private Task<List<TableReservationBracketDto>> BuildTableReservationBracketDtoAsync(List<TableBase> tables, List<ReservationDto>? reservations, int openingHour, int closeHour)
    {
        var tableBrackets = new List<TableReservationBracketDto>();
        var timeBrackets = new List<TableTimeBracketDto>();

        foreach (var table in tables)
        {
            var freqOfRsvp = table.FrequencyOfReservation;
            for (var i = openingHour; i < closeHour; i += freqOfRsvp)
            {
                var isReserved = reservations.Where(rsvp => rsvp.StartTime == i);
                timeBrackets.Add(new()
                {
                    StartTime = i,
                    EndTime = i + freqOfRsvp,
                    IsAvailable = isReserved.Any(),
                    Reservation = isReserved.FirstOrDefault()
                });
            }
            tableBrackets.Add(new()
            {
                Table = _mapper.Map<TableDto>(table),
                TablesTimeBrackets = timeBrackets
            });
        }

        return Task.FromResult(tableBrackets);
    }

    private Task<(int openingHour, int closingHour)> GetDayOfTheWeekOpeningAndClosingHoursAsync(ScheduleBase schedule, DateTime dateOfRequest)
    {
        var day = DateTime.Now.Date;
        if (dateOfRequest.Date > day)
            day = dateOfRequest.Date;

        var openingHours = 0;
        var closingHours = 0;
        var hours = (openingHours, closingHours);
        switch (day.DayOfWeek)
        {
            case DayOfWeek.Sunday:
                if (schedule.Sunday)
                    hours = (schedule.SundayOpenTime, schedule.SundayCloseTime);
                break;
            case DayOfWeek.Monday:
                if (schedule.Monday)
                    hours = (schedule.MondayOpenTime, schedule.MondayCloseTime);
                break;
            case DayOfWeek.Tuesday:
                if (schedule.Tuesday)
                    hours = (schedule.TuesdayOpenTime, schedule.TuesdayCloseTime);
                break;
            case DayOfWeek.Wednesday:
                if (schedule.Wednesday)
                    hours = (schedule.WednesdayOpenTime, schedule.WednesdayCloseTime);
                break;
            case DayOfWeek.Thursday:
                if (schedule.Thursday)
                    hours = (schedule.ThursdayOpenTime, schedule.ThursdayCloseTime);
                break;
            case DayOfWeek.Friday:
                if (schedule.Friday)
                    hours = (schedule.FridayOpenTime, schedule.FridayCloseTime);
                break;
            case DayOfWeek.Saturday:
                if (schedule.Saturday)
                    hours = (schedule.SaturdayOpenTime, schedule.SaturdayCloseTime);
                break;
        }
        return Task.FromResult(hours);
    }

    #endregion
}