using AutoMapper;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Models.NavigationMenuModels;
using Models.TableModels;
using Services.TableServices;
using StaticData;

namespace BonAppetitManagerApp.Pages.TablesComponents;

[Authorize(Roles = Role.Manager)]
public partial class Tables
{
    #region Dependencies

    [Inject] private ITableService _tableService { get; set; }
    [Inject] private ISessionStorageService _sessionStorage { get; set; }
    [Inject] private IMapper _mapper { get; set; }

    #endregion
    private List<Table?> TablesList { get; set; } = new();

    protected override async Task OnInitializedAsync()
    {
        await SetNavigationPropertiesAsync();
        await GetRestaurantTablesAsync();
    }
    private async Task GetRestaurantTablesAsync()
    {
        var request = await _tableService.GetRestaurantTables();
        if (request.IsSuccessful)
            TablesList = request.ResponseObject!;
    }
    private async Task SetNavigationPropertiesAsync()
    {
        await _sessionStorage.SetItemAsync(Storage.NavigationProperties, new NavigationMenu
        {
            DashboardMenuSelection = "Tables",
            DashboardTopMenuSelection = "Tables Information"
        });
    }
    private Task TableDeletedCallback(string tableId)
    {
        var tableToRemove = TablesList.Where(table => table!.TableId == tableId)!.FirstOrDefault();
        TablesList.Remove(tableToRemove);
        return Task.CompletedTask;
    }
}