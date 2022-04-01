using Microsoft.AspNetCore.Components;
using Models.RestaurantModels;

namespace BonAppetitRestaurantManagerApp.Pages;

public partial class RegisterRestaurant
{
    private RestaurantCreateVm RestaurantCreateVm { get; set; } = new();

    private async Task RegisterFormSumbit()
    {
        //Service call to restaurant service!
    }

}