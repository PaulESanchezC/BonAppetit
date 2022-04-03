using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Models.RestaurantModels;

namespace BonAppetitRestaurantManagerApp.Pages;

[Authorize]
public partial class RegisterRestaurant
{
    private RestaurantCreateVm RestaurantCreateVm { get; set; } = new();

    private async Task RegisterFormSumbit()
    {
        //Service call to restaurant service!
    }

}