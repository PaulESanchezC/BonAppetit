using Microsoft.AspNetCore.Components;

namespace BonAppetitWebApp.Pages.RegistrationComponents;

public partial class RegistrationConfirmed
{
    [Parameter] public bool IsRegistered { get; set; } = false;
}