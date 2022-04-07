using Microsoft.AspNetCore.Components;
using Models.RestaurantModels;
using Services.RestaurantServices;

namespace BonAppetitWebApp.Pages;

public partial class Index
{
    [Inject]
    private IRestaurantService _restaurantService { get; set; }

    public List<Restaurant> IndexRestaurants { get; set; } = new();

    protected override async Task OnInitializedAsync()
    {
        var request = await _restaurantService.GetAllRestaurantsAsync();
        if (request.IsSuccessful)
        {
            IndexRestaurants = request.ResponseObject!;
        }
    }
}