using AutoMapper;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Models.DashboardVm.Schedules;
using Models.NavigationMenuModels;
using Models.RestaurantModels;
using Models.ScheduleModels;
using Services.ScheduleServices;
using StaticData;

namespace BonAppetitManagerApp.Pages.RestaurantComponents;

[Authorize(Roles = Role.Manager)]
public partial class RestaurantSchedule
{
    #region Dependencies

    [Inject] private IScheduleServices _scheduleService { get; set; }
    [Inject] private ISessionStorageService _sessionStorage { get; set; }
    [Inject] private IMapper _mapper { get; set; }

    #endregion

    private Schedule Schedule { get; set; } = new();
    private SchedulesVm ScheduleVm { get; set; } = new();
    private Restaurant Restaurant { get; set; } = new();


    protected override async Task OnInitializedAsync()
    {
        await SetNavigationPropertiesAsync();
        await GetScheduleAsync();
    }

    private async Task GetScheduleAsync()
    {
        Restaurant = await _sessionStorage.GetItemAsync<Restaurant>(Storage.RestaurantInformation);
        Schedule = Restaurant.RestaurantSchedule;
        ScheduleVm = await _scheduleService.MapScheduleToScheduleVmTask(Schedule);
    }

    private async Task UpdateScheduleAsync()
    {
        Schedule = await _scheduleService.MapScheduleVmToScheduleTask(ScheduleVm);

        var scheduleToUpdate = _mapper.Map<ScheduleUpdate>(Schedule);
        var request = await _scheduleService.UpdateScheduleAsync(scheduleToUpdate);
        if (request.IsSuccessful)
        {
            Schedule = request.ResponseObject!.FirstOrDefault()!;
            Restaurant.RestaurantSchedule = Schedule;
            await _sessionStorage.SetItemAsync(Storage.RestaurantInformation, Restaurant);
        }

    }

    private async Task SetNavigationPropertiesAsync()
    {
        await _sessionStorage.SetItemAsync(Storage.NavigationProperties, new NavigationMenu
        {
            DashboardMenuSelection = "Restaurant",
            DashboardTopMenuSelection = "Restaurant Schedule"
        });
    }
}