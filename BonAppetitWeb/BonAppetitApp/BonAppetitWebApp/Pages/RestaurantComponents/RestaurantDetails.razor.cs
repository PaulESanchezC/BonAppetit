using Microsoft.AspNetCore.Components;
using Models.RestaurantModels;
using Services.RestaurantServices;

namespace BonAppetitWebApp.Pages.RestaurantComponents;

public partial class RestaurantDetails
{
    #region Dependencies
    [Parameter] public string RestaurantId { get; set; }
    [Inject] private IRestaurantService _restaurantService { get; set; }
    #endregion

    public Restaurant Restaurant { get; set; } = new();

    protected override async Task OnInitializedAsync()
    {
        var request = await _restaurantService.GetSingleRestaurantAsync(RestaurantId);
        if (request.IsSuccessful)
            Restaurant = request.ResponseObject!.FirstOrDefault()!;
    }
}