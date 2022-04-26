using Blazored.LocalStorage;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Models.ResponseModels;
using Models.RestaurantModels;
using Services.RestaurantServices;
using StaticData;

namespace BonAppetitManagerApp.Pages.DashboardComponents;

[Authorize(Roles = Role.Manager)]
public partial class Dashboard
{
    #region Dependencies

    [Inject] private IRestaurantService _restaurantService { get; set; }
    [Inject] private ISessionStorageService _sessionStorage { get; set; }
    public string Component { get; set; } = "Analytics";

    #endregion

    #region TopMenuItemLists

    private List<string> RestaurantTopMenuList { get; set; } = new();
    private List<string> AnalyticsTopMenuList { get; set; } = new();
    private List<string> TablesTopMenuList { get; set; } = new();
    private List<string> ReservationsTopMenuList { get; set; } = new();
    private List<string> MenusTopMenuList { get; set; } = new();
    private List<string> CouponTopMenuList { get; set; } = new();

    #endregion

    private string UserId { get; set; } = "";

    protected override async Task OnInitializedAsync()
    {
        await BuildRestaurantSessionAsync();
        await Task.FromResult(BuildTopMenuListsTask()) ;
    }

    private void DashboardMenuSelection(string dashboardMenuSelection)
    {
        Component = dashboardMenuSelection;
    }
    private async Task BuildRestaurantSessionAsync()
    {
        UserId = await _sessionStorage.GetItemAsStringAsync(Storage.RestaurantId);
        var request = await _restaurantService.GetRestaurantAsync(UserId);
        if (request.IsSuccessful)
            await _sessionStorage.SetItemAsync(Storage.RestaurantInformation, request.ResponseObject!.FirstOrDefault()!);
    }
    private Task BuildTopMenuListsTask()
    {
        RestaurantTopMenuList = new()
        {
            "Restaurant Information",
            "Restaurant Schedule"
        };
        AnalyticsTopMenuList= new()
        {
            "Reservations Analysis",
            "Coupon Reservations Analysis",
            "Menus Analysis Researches"
        };
        TablesTopMenuList = new()
        {
            "Tables Information",
            "Add Table"
        };
        ReservationsTopMenuList = new()
        {
            "Today's Reservations",
            "Search for Reservation",
        };
        MenusTopMenuList = new()
        {
            "Active Menus",
            "Public Menus",
            "Private Menus",
            "Add Menu"
        };
        CouponTopMenuList = new()
        {
            "Coupons Active",
            "Track Coupon",
            "Create Coupon"
        };
        return Task.CompletedTask;
    }

}