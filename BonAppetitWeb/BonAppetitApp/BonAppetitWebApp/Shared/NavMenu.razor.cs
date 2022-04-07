using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

namespace BonAppetitWebApp.Shared;

public partial class NavMenu
{
    [Inject]
    private SignOutSessionStateManager _signOutManager { get; set; }

    [Inject]
    private NavigationManager _navigation { get; set; }

    private async Task BeginSignOut()
    {
        await _signOutManager.SetSignOutState();
        _navigation.NavigateTo("authentication/logout");
    }
}