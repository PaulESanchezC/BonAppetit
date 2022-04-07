using Microsoft.AspNetCore.Components;
using Models.RestaurantModels;

namespace BonAppetitWebApp.Pages.RestaurantComponents;

public partial class IndexRestaurantComponent
{
    [Parameter]
    public Restaurant Restaurant { get; set; }

    [Inject]
    private NavigationManager _navigation { get; set; }

    private void RestaurantDetailsRedirect(string restaurantId)
    {
        _navigation.NavigateTo($"/RestaurantDetails/{restaurantId}");
    }
}