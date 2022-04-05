using Microsoft.AspNetCore.Components;

namespace BonAppetitRestaurantManagerApp.Shared;

public partial class RedirectToLogin
{
    [Inject]
    private NavigationManager _navigation { get; set; }

    protected override void OnInitialized()
    {
        _navigation.NavigateTo("/Authentication/login?returnUrl=" + Uri.EscapeDataString(_navigation.Uri));
    }
}