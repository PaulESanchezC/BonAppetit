using System.Net.Http.Headers;
using System.Text;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Models.DashboardVm.Schedules;
using Models.ResponseModels;
using Models.RestaurantModels;
using Models.ScheduleModels;
using Newtonsoft.Json;
using StaticData;

namespace Services.ScheduleServices;

public class ScheduleServices : IScheduleServices
{
    #region Dependencies

    private HttpClient _httpClient;
    private readonly IAccessTokenProvider _accessToken;
    private readonly AuthenticationStateProvider _authState;

    private string RestaurantId { get; set; }
    private string Token { get; set; }

    public ScheduleServices(HttpClient httpClient, IAccessTokenProvider accessToken, AuthenticationStateProvider authState)
    {
        _httpClient = httpClient;
        _accessToken = accessToken;
        _authState = authState;

        RestaurantId = "";
        Token = "";
    }

    #endregion

    public async Task<Response<Schedule>> GetScheduleAsync()
    {
        await GetRestaurantIdAsync();
        var request = new HttpRequestMessage(HttpMethod.Get, $"https://localhost:44310/api/Schedule/GetSingleRestaurantSchedule/{RestaurantId}");
        var client = await _httpClient.SendAsync(request);
        var responseString = await client.Content.ReadAsStringAsync();
        var response = JsonConvert.DeserializeObject<Response<Schedule>>(responseString);
        return response!;
    }

    public async Task<Response<Schedule>> UpdateScheduleAsync(ScheduleUpdate scheduleToUpdate)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:44310/api/Schedule/UpdateSingleRestaurantSchedule");
        request.Content = new StringContent(JsonConvert.SerializeObject(scheduleToUpdate), Encoding.UTF8,
            "Application/json");

        await GetTokenAsync();
        request.Headers.Authorization = new AuthenticationHeaderValue(JwtBearerOptions.AuthenticationScheme, Token);

        var client = await _httpClient.SendAsync(request);
        var responseString = await client.Content.ReadAsStringAsync();
        var response = JsonConvert.DeserializeObject<Response<Schedule>>(responseString);

        return response!;
    }

    public Task<Schedule> MapScheduleVmToScheduleTask(SchedulesVm scheduleVm)
    {
        var schedule = new Schedule();

        schedule.MondayOpenTime = TimeParser(scheduleVm.MondayOpenTime);
        schedule.MondayCloseTime = TimeParser(scheduleVm.MondayCloseTime);
        schedule.TuesdayOpenTime = TimeParser(scheduleVm.TuesdayOpenTime);
        schedule.TuesdayCloseTime = TimeParser(scheduleVm.TuesdayCloseTime);
        schedule.WednesdayOpenTime = TimeParser(scheduleVm.WednesdayOpenTime);
        schedule.WednesdayCloseTime = TimeParser(scheduleVm.WednesdayCloseTime);
        schedule.ThursdayOpenTime = TimeParser(scheduleVm.ThursdayOpenTime);
        schedule.ThursdayCloseTime = TimeParser(scheduleVm.ThursdayCloseTime);
        schedule.FridayOpenTime = TimeParser(scheduleVm.FridayOpenTime);
        schedule.FridayCloseTime = TimeParser(scheduleVm.FridayCloseTime);
        schedule.SaturdayOpenTime = TimeParser(scheduleVm.SaturdayOpenTime);
        schedule.SaturdayCloseTime = TimeParser(scheduleVm.SaturdayCloseTime);
        schedule.SundayOpenTime = TimeParser(scheduleVm.SundayOpenTime);
        schedule.SundayCloseTime = TimeParser(scheduleVm.SundayCloseTime);

        schedule.Monday = scheduleVm.Monday;
        schedule.Tuesday = scheduleVm.Tuesday;
        schedule.Wednesday = scheduleVm.Wednesday;
        schedule.Thursday = scheduleVm.Thursday;
        schedule.Friday = scheduleVm.Friday;
        schedule.Saturday = scheduleVm.Saturday;
        schedule.Sunday = scheduleVm.Sunday;

        schedule.RestaurantId = scheduleVm.RestaurantId;
        schedule.ScheduleId = scheduleVm.ScheduleId;

        return Task.FromResult(schedule);
    }

    public Task<SchedulesVm> MapScheduleToScheduleVmTask(Schedule schedule)
    {
        var scheduleVm = new SchedulesVm();

        scheduleVm.MondayOpenTime = StringParser(schedule.MondayOpenTime);
        scheduleVm.MondayCloseTime = StringParser(schedule.MondayCloseTime);
        scheduleVm.TuesdayOpenTime = StringParser(schedule.TuesdayOpenTime);
        scheduleVm.TuesdayCloseTime = StringParser(schedule.TuesdayCloseTime);
        scheduleVm.WednesdayOpenTime = StringParser(schedule.WednesdayOpenTime);
        scheduleVm.WednesdayCloseTime = StringParser(schedule.WednesdayCloseTime);
        scheduleVm.ThursdayOpenTime = StringParser(schedule.ThursdayOpenTime);
        scheduleVm.ThursdayCloseTime = StringParser(schedule.ThursdayCloseTime);
        scheduleVm.FridayOpenTime = StringParser(schedule.FridayOpenTime);
        scheduleVm.FridayCloseTime = StringParser(schedule.FridayCloseTime);
        scheduleVm.SaturdayOpenTime = StringParser(schedule.SaturdayOpenTime);
        scheduleVm.SaturdayCloseTime = StringParser(schedule.SaturdayCloseTime);
        scheduleVm.SundayOpenTime = StringParser(schedule.SundayOpenTime);
        scheduleVm.SundayCloseTime = StringParser(schedule.SundayCloseTime);

        scheduleVm.Monday = schedule.Monday;
        scheduleVm.Tuesday = schedule.Tuesday;
        scheduleVm.Wednesday = schedule.Wednesday;
        scheduleVm.Thursday = schedule.Thursday;
        scheduleVm.Friday = schedule.Friday;
        scheduleVm.Saturday = schedule.Saturday;
        scheduleVm.Sunday = schedule.Sunday;

        scheduleVm.RestaurantId = schedule.RestaurantId;
        scheduleVm.ScheduleId = schedule.ScheduleId;

        return Task.FromResult(scheduleVm);
    }

    #region Helper Methods

    private async Task GetTokenAsync()
    {
        var tokenProvider = await _accessToken.RequestAccessToken();
        tokenProvider.TryGetToken(out var token);
        Token = token.Value;
    }

    private async Task GetRestaurantIdAsync()
    {
        var userClaims = await _authState.GetAuthenticationStateAsync();
        RestaurantId = userClaims.User.FindFirst(claim => claim.Type == "sub")!.Value;
    }

    private double TimeParser(string time)
    {
        var hours = "";
        var minutes = "";
        var parsedTime = 0.0;

        hours = time.Split(':')[0];
        minutes = time.Split(':')[1];
        parsedTime = double.Parse($"{hours},{double.Parse(minutes) / 60}");
        return parsedTime;
    }

    private string StringParser(double time)
    {
        var hour = 0.0;
        var minute = 0.00;

        hour = time / 1;
        minute = time % 1;
        minute *= 60;

        return $"{hour:##}:{minute:00}";
    }

    #endregion
}