using Microsoft.AspNetCore.Components;
using Models.RestaurantModels;
using Services.RestaurantServices;

namespace BonAppetitRestaurantManagerApp.Pages;

public partial class Index
{
    [Inject] private IRestaurantService _restaurant { get; set; }
    public Restaurant Restaurant { get; set; } = new ();

    protected override async Task OnInitializedAsync()
    {
        var response = await _restaurant.GetRestaurantByIdAsync("deabdd54-7e33-4b6b-98ac-7416da57c49d");
        Restaurant = response!.ResponseObject!.FirstOrDefault()!;
    }
}