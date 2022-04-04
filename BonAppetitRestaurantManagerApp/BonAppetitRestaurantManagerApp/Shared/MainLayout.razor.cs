using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

namespace BonAppetitRestaurantManagerApp.Shared;

public partial class MainLayout
{
    [Inject]
    private NavigationManager _navigationManager { get; set; }

    [Inject]
    private SignOutSessionStateManager _SignOutManager { get; set; }

    private async Task Logout()
    {
        await _SignOutManager.SetSignOutState();
        _navigationManager.NavigateTo("Authorization/Logout");
    }
}