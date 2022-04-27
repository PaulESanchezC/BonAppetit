using Blazored.SessionStorage;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Services.RestaurantServices;
using StaticData;
using NavigationMenu = Models.NavigationMenuModels.NavigationMenu;

namespace BonAppetitManagerApp.Pages.DashboardComponents;

[Authorize(Roles = Role.Manager)]
public partial class Dashboard
{
    #region Dependencies
    [Inject] private IRestaurantService _restaurantService { get; set; }
    [Inject] private ISessionStorageService _sessionStorage { get; set; }
    public string Component { get; set; } = "Analytics";
    public string TopMenuSelection { get; set; } = "";

    #endregion

    #region TopMenuItemLists

    public NavigationMenu NavigationMenu { get; set; } = new();
    private List<string> RestaurantTopMenuList { get; set; } = new();
    private List<string> AnalyticsTopMenuList { get; set; } = new();
    private List<string> TablesTopMenuList { get; set; } = new();
    private List<string> ReservationsTopMenuList { get; set; } = new();
    private List<string> MenusTopMenuList { get; set; } = new();
    private List<string> CouponTopMenuList { get; set; } = new();

    #endregion

    protected override async Task OnInitializedAsync()
    {
        await BuildRestaurantSessionAsync();
        await Task.FromResult(BuildTopMenuListsTask());
        await GetSessionNavigationPropertiesAsync();
    }

    private void DashboardMenuSelection(NavigationMenu navigationProperties)
    {
        Component = navigationProperties.DashboardMenuSelection;
        TopMenuSelection = navigationProperties.DashboardTopMenuSelection;
    }
    private async Task BuildRestaurantSessionAsync()
    {
        var request = await _restaurantService.GetRestaurantAsync();
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
    private async Task GetSessionNavigationPropertiesAsync()
    {
        NavigationMenu = await _sessionStorage.GetItemAsync<NavigationMenu>(Storage.NavigationProperties);
        if (NavigationMenu is not null)
        {
            Component = NavigationMenu.DashboardMenuSelection;
            TopMenuSelection = NavigationMenu.DashboardTopMenuSelection;
            Console.WriteLine($"Last known navigation properties : {Component} / {TopMenuSelection} ");
        }
    }
}