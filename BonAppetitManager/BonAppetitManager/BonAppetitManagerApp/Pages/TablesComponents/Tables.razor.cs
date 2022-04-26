using AutoMapper;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Models.NavigationMenuModels;
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
    protected override async Task OnInitializedAsync()
    {
        await SetNavigationPropertiesAsync();
    }
    private async Task SetNavigationPropertiesAsync()
    {
        await _sessionStorage.SetItemAsync(Storage.NavigationProperties, new NavigationMenu
        {
            DashboardMenuSelection = "Tables",
            DashboardTopMenuSelection = "Tables Information"
        });
    }
}