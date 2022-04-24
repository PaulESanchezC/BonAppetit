using System.Security.Claims;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
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
    [Inject] private AuthenticationStateProvider _authState { get; set; }
    [Inject] private NavigationManager _navigationManager { get; set; }
    [Inject] private ILocalStorageService _localStorage { get; set; }

    #endregion

    private Restaurant Restaurant { get; set; } = new();
    private Response<Restaurant> Request { get; set; } = new();
    private string UserId { get; set; } = "";

    protected override async Task OnInitializedAsync()
    {
        var userClaims = await _authState.GetAuthenticationStateAsync();
        UserId = userClaims.User.FindFirst(claim => claim.Type == "sub")!.Value;
        if (string.IsNullOrEmpty(UserId))
            _navigationManager.NavigateTo("/Authentication/logout");

        await _localStorage.SetItemAsStringAsync(LocalStorage.RestaurantId, UserId);

        Request = await _restaurantService.GetRestaurantAsync(UserId);
        if (Request.IsSuccessful)
        {
            Restaurant = Request.ResponseObject!.FirstOrDefault()!;
            await _localStorage.SetItemAsync(LocalStorage.RestaurantInformation, Restaurant);
        }

        await BuildRestaurantProfileData(userClaims);
    }

    private async Task BuildRestaurantProfileData(AuthenticationState userClaims)
    {
        var name = userClaims.User.FindFirst(claim => claim.Type == "given_name")!.Value;
        var phone = userClaims.User.FindFirst(claim => claim.Type == "phone_number")!.Value;
        var username = userClaims.User.FindFirst(claim => claim.Type == "preferred_username")!.Value;

        await _localStorage.SetItemAsync(LocalStorage.RestaurantName, name);
        await _localStorage.SetItemAsync(LocalStorage.RestaurantPhone, phone);
        await _localStorage.SetItemAsync(LocalStorage.RestaurantUsername, username);
    }

}