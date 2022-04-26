using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using StaticData;

namespace BonAppetitManagerApp.Pages;

public partial class Index
{
    #region Dependencies

    [Inject] private ISessionStorageService _sessionStorage { get; set; }
    [Inject] private NavigationManager _navigationManager { get; set; }
    [Inject] private AuthenticationStateProvider _authState { get; set; }

    #endregion
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        var authentication = await _authState.GetAuthenticationStateAsync();
        if (authentication.User.Identity!.IsAuthenticated)
            Console.WriteLine("User is authenticated");
        await base.OnAfterRenderAsync(firstRender);
    }
}