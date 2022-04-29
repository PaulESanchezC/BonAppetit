using Microsoft.AspNetCore.Components;
using Models.ApplicationUserModels;
using Services.UserRegistrationServices;

namespace BonAppetitWebApp.Pages.RegistrationComponents;

public partial class UserRegistration
{
    #region Dependencies
    [Inject]private IUserRegistrationService _userRegistrationService { get; set; }
    [Inject] private NavigationManager _navigationManager { get; set; }
    #endregion

    private ApplicationUserCreate ApplicationUserCreate { get; set; } = new();

    protected override void OnInitialized()
    {
        ApplicationUserCreate.FirstName = "Restaurant";
        ApplicationUserCreate.LastName = "Restaurant";
        ApplicationUserCreate.PhoneNumber = "Restaurant";
    }

    private async Task RegisterUser()
    {
        var request = await _userRegistrationService.RegisterUserAsync(ApplicationUserCreate);
        if (request.IsSuccessful)
            _navigationManager.NavigateTo("/authentication/login");
    }
}