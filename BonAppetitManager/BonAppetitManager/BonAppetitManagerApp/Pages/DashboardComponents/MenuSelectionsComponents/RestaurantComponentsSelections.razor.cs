using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using StaticData;

namespace BonAppetitManagerApp.Pages.DashboardComponents.MenuSelectionsComponents;

[Authorize(Roles = Role.Manager)]
public partial class RestaurantComponentsSelections
{
    [Parameter] public List<string> TopMenuList { get; set; } = new();
    [Parameter] public string Selection { get; set; } = "Restaurant Information";

    private Task MenuSelectionTask(string selection)
    {
        Selection = selection;
        return Task.CompletedTask;
    }

    protected override void OnInitialized()
    {
        if (string.IsNullOrEmpty(Selection))
            Selection = "Restaurant Information";
    }
}