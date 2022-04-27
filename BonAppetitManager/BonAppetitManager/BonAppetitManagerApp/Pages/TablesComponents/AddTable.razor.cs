using AutoMapper;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Models.NavigationMenuModels;
using Models.TableModels;
using Services.TableServices;
using StaticData;

namespace BonAppetitManagerApp.Pages.TablesComponents;

[Authorize(Roles=Role.Manager)]
public partial class AddTable
{
    #region Dependencies

    [Inject] private NavigationManager _navigationManager { get; set; }
    [Inject] private ITableService _tableService { get; set; }
    [Inject] private ISessionStorageService _sessionStorage { get; set; }

    #endregion

    private TableCreate TableCreate { get; set; } = new();

    protected override async Task OnInitializedAsync()
    {
        await SetNavigationPropertiesAsync();
        TableCreate.RestaurantId = await _sessionStorage.GetItemAsStringAsync(Storage.RestaurantId);
    }
    private async Task CreateTableAsync()
    {
        TableCreate.FrequencyOfReservation /= 60;
        var request = await _tableService.CreateTableAsync(TableCreate);
        if (request.IsSuccessful)
        {
            await _sessionStorage.SetItemAsync(Storage.NavigationProperties, new NavigationMenu
            {
                DashboardMenuSelection = "Tables",
                DashboardTopMenuSelection = "Tables Information"
            });
            TableCreate.FrequencyOfReservation *= 60;
        }
    }
    private async Task SetNavigationPropertiesAsync()
    {
        await _sessionStorage.SetItemAsync(Storage.NavigationProperties, new NavigationMenu
        {
            DashboardMenuSelection = "Tables",
            DashboardTopMenuSelection = "Add Table"
        });
    }
}