using AutoMapper;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Models.NavigationMenuModels;
using Models.ResponseModels;
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
    [Inject] private IMapper _mapper { get; set; }

    #endregion

    private Restaurant Restaurant { get; set; } = new();
    private bool DoesRestaurantExist { get; set; } = false;

    protected override async Task OnInitializedAsync()
    {
        await SetNavigationPropertiesAsync();
        DoesRestaurantExist = await GetRestaurantAsync();
    }

    private async Task<bool> GetRestaurantAsync()
    {
        var request = await _restaurantService.GetRestaurantAsync();
        if (request.IsSuccessful)
        {
            Restaurant = request.ResponseObject!.FirstOrDefault()!;
            await _sessionStorage.SetItemAsync(Storage.RestaurantInformation, Restaurant);
        }
        return request.IsSuccessful;
    }

    private async Task CreateOrUpdateRestaurant()
    {
        var request = new Response<Restaurant>();

        if (DoesRestaurantExist)
        {
            var restaurantToUpdate = _mapper.Map<RestaurantUpdate>(Restaurant);
            request = await _restaurantService.UpdateRestaurantAsync(restaurantToUpdate);
            if (request.IsSuccessful)
            {
                Restaurant = request.ResponseObject!.FirstOrDefault()!;
                await _sessionStorage.SetItemAsync(Storage.RestaurantInformation, Restaurant);
            }
        }
        if (!DoesRestaurantExist)
        {
            var restaurantToCreate = _mapper.Map<RestaurantCreate>(Restaurant);
            request = await _restaurantService.CreateRestaurantAsync(restaurantToCreate);
            if (request.IsSuccessful)
            {
                Restaurant = request.ResponseObject!.FirstOrDefault()!;
                await _sessionStorage.SetItemAsync(Storage.RestaurantInformation, Restaurant);
            }
        }
    }

    private async Task SetNavigationPropertiesAsync()
    {
        await _sessionStorage.SetItemAsync(Storage.NavigationProperties, new NavigationMenu
        {
            DashboardMenuSelection = "Restaurant",
            DashboardTopMenuSelection = "Restaurant Information"
        });
    }
}