using Microsoft.AspNetCore.Components;

namespace BonAppetitRestaurantManagerApp;

public partial class Authentication
{
    [Parameter]
    public string? Action { get; set; }
}