using AutoMapper;
using Data;
using Microsoft.EntityFrameworkCore;
using Models.ReservationModels;
using Models.ResponseModels;
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

        var tableReservationsRequest = await GetTableReservationsAsync(restaurantId, cancellationToken);
        if (!tableReservationsRequest.IsSuccessful)
            return new Response<TableReservationBracketDto>
            {
                IsSuccessful = tableReservationsRequest.IsSuccessful,
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

        var day = DateTime.Now;
        if (dateOfRequest > DateTime.Now)
            day = dateOfRequest;

        var openingHours = 0;
        var closingHours = 0;
        switch (day.DayOfWeek)
        {
            case DayOfWeek.Sunday:
                if (!restaurantSchedule.Sunday)
                    return new Response<TableReservationBracketDto>()
                    {
                        IsSuccessful = false,
                        StatusCode = 400,
                        Title = "Restaurant Closed",
                        Message = "Restaurant Closed",
                        ResponseObject = null,
                    };
                openingHours = restaurantSchedule.SundayOpenTime;
                closingHours = restaurantSchedule.SundayCloseTime;
                break;
            case DayOfWeek.Monday:
                if (!restaurantSchedule.Monday)
                    return new Response<TableReservationBracketDto>()
                    {
                        IsSuccessful = false,
                        StatusCode = 400,
                        Title = "Restaurant Closed",
                        Message = "Restaurant Closed",
                        ResponseObject = null,
                    };
                openingHours = restaurantSchedule.MondayOpenTime;
                closingHours = restaurantSchedule.MondayCloseTime;
                break;
            case DayOfWeek.Tuesday:
                if (!restaurantSchedule.Tuesday)
                    return new Response<TableReservationBracketDto>()
                    {
                        IsSuccessful = false,
                        StatusCode = 400,
                        Title = "Restaurant Closed",
                        Message = "Restaurant Closed",
                        ResponseObject = null,
                    };
                openingHours = restaurantSchedule.TuesdayOpenTime;
                closingHours = restaurantSchedule.TuesdayCloseTime;
                break;
            case DayOfWeek.Wednesday:
                if (!restaurantSchedule.Wednesday)
                    return new Response<TableReservationBracketDto>()
                    {
                        IsSuccessful = false,
                        StatusCode = 400,
                        Title = "Restaurant Closed",
                        Message = "Restaurant Closed",
                        ResponseObject = null,
                    };
                openingHours = restaurantSchedule.WednesdayOpenTime;
                closingHours = restaurantSchedule.WednesdayCloseTime;
                break;
            case DayOfWeek.Thursday:
                if (!restaurantSchedule.Thursday)
                    return new Response<TableReservationBracketDto>()
                    {
                        IsSuccessful = false,
                        StatusCode = 400,
                        Title = "Restaurant Closed",
                        Message = "Restaurant Closed",
                        ResponseObject = null,
                    };
                openingHours = restaurantSchedule.ThursdayCloseTime;
                closingHours = restaurantSchedule.ThursdayCloseTime;
                break;
            case DayOfWeek.Friday:
                if (!restaurantSchedule.Friday)
                    return new Response<TableReservationBracketDto>()
                    {
                        IsSuccessful = false,
                        StatusCode = 400,
                        Title = "Restaurant Closed",
                        Message = "Restaurant Closed",
                        ResponseObject = null,
                    };
                openingHours = restaurantSchedule.FridayOpenTime;
                closingHours = restaurantSchedule.FridayCloseTime;
                break;
            case DayOfWeek.Saturday:
                if (!restaurantSchedule.Saturday)
                    return new Response<TableReservationBracketDto>()
                    {
                        IsSuccessful = false,
                        StatusCode = 400,
                        Title = "Restaurant Closed",
                        Message = "Restaurant Closed",
                        ResponseObject = null,
                    };
                openingHours = restaurantSchedule.SaturdayOpenTime;
                closingHours = restaurantSchedule.SaturdayCloseTime;
                break;
        }

        var tableBrackets = new List<TableReservationBracketDto>();
        var timeBrackets = new List<TableTimeBracketDto>();
        foreach (var table in tables)
        {
            var freqOfRsvp = table.FrequencyOfReservation;
            for (var i = openingHours; i < closingHours; i += freqOfRsvp)
            {
                var isReserved = tableReservations.Where(rsvp => rsvp.StartTime == i );
                timeBrackets.Add(new()
                {
                    StartTime = i,
                    EndTime = i+freqOfRsvp,
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

        return new Response<TableReservationBracketDto>
        {
            IsSuccessful = true,
            StatusCode = 200,
            Title = "Ok",
            Message = "Ok",
            ResponseObject = tableBrackets
        };
    }

    #region Helper Methods

    private async Task<Response<ReservationDto>> GetTableReservationsAsync(string restaurantId, CancellationToken cancellationToken)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, $"https://localhost:44314/api/Reservation/GetAllValidReservationsForRestaurant/{restaurantId}");
        var client = await _httpClientFactory.CreateClient().SendAsync(request, cancellationToken);
        var responseString = await client.Content.ReadAsStringAsync(cancellationToken);
        var reservationsResponse = JsonConvert.DeserializeObject<Response<ReservationDto>>(responseString);
        return reservationsResponse!;
    }

    #endregion
}