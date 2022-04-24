using Blazored.LocalStorage;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Models.RestaurantModels;
using Services.RestaurantServices;
using StaticData;

namespace BonAppetitManagerApp.Pages.RegistrationComponents;

[Authorize(Roles = Role.Manager)]
public partial class RestaurantRegistration
{
    #region Dependencies

    [Inject] private IRestaurantService _restaurantService { get; set; }
    [Inject] private ILocalStorageService _localStorage { get; set; }
    [Inject] private NavigationManager _navigationManager { get; set; }

    #endregion

    private Restaurant Restaurant { get; set; } = new();
    private RestaurantCreate RestaurantCreate { get; set; } = new();

    protected override async Task OnInitializedAsync()
    {
        RestaurantCreate.RestaurantId = await _localStorage.GetItemAsStringAsync(LocalStorage.RestaurantId);
        RestaurantCreate.RestaurantName = await _localStorage.GetItemAsStringAsync(LocalStorage.RestaurantName);
        RestaurantCreate.RestaurantPhone = await _localStorage.GetItemAsStringAsync(LocalStorage.RestaurantPhone);
        RestaurantCreate.RestaurantEmail = await _localStorage.GetItemAsStringAsync(LocalStorage.RestaurantUsername);
    }

    private async Task CreateRestaurant()
    {
        var request = await _restaurantService.CreateRestaurantAsync(RestaurantCreate);
        if (request.IsSuccessful)
        {
            Restaurant = request.ResponseObject!.FirstOrDefault()!;
            await _localStorage.SetItemAsync(LocalStorage.RestaurantInformation, Restaurant);
            _navigationManager.NavigateTo("/Dashboard");
        }
    }
}