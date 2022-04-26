using Blazored.SessionStorage;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Models.RestaurantModels;
using Services.RestaurantServices;
using StaticData;

namespace BonAppetitManagerApp.Pages.RestaurantComponents;

[Authorize(Roles = Role.Manager)]
public partial class RestaurantInformation
{
    #region Dependencies

    [Inject] private IRestaurantService _restaurantService { get; set; }
    [Inject] private ISessionStorageService _sessionStorage { get; set; }
    [Inject] private NavigationManager _navigationManager { get; set; }

    #endregion

    private Restaurant Restaurant { get; set; } = new();
    private RestaurantCreate RestaurantCreate { get; set; } = new();

    protected override async Task OnInitializedAsync()
    {
        RestaurantCreate.RestaurantId = await _sessionStorage.GetItemAsStringAsync(Storage.RestaurantId);
        RestaurantCreate.RestaurantName = await _sessionStorage.GetItemAsStringAsync(Storage.RestaurantName);
        RestaurantCreate.RestaurantPhone = await _sessionStorage.GetItemAsStringAsync(Storage.RestaurantPhone);
        RestaurantCreate.RestaurantEmail = await _sessionStorage.GetItemAsStringAsync(Storage.RestaurantUsername);
    }

    private async Task CreateRestaurant()
    {
        var request = await _restaurantService.CreateRestaurantAsync(RestaurantCreate);
        if (request.IsSuccessful)
        {
            Restaurant = request.ResponseObject!.FirstOrDefault()!;
            await _sessionStorage.SetItemAsync(Storage.RestaurantInformation, Restaurant);
            _navigationManager.NavigateTo("/Dashboard");
        }
    }
}