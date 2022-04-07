using Microsoft.AspNetCore.Components;
using Models.RestaurantModels;
using Services.RestaurantServices;

namespace BonAppetitWebApp.Pages.RestaurantComponents;

public partial class RestaurantDetails
{
    [Parameter]
    public string RestaurantId { get; set; }

    [Inject]
    private IRestaurantService _restaurantService { get; set; }

    public Restaurant Restaurant { get; set; }
    protected override async Task OnInitializedAsync()
    {
        var request = await _restaurantService.GetSingleRestaurantAsync(RestaurantId);
        if (request.IsSuccessful)
        {
            Restaurant = request.ResponseObject!.FirstOrDefault()!;
        }
    }
}