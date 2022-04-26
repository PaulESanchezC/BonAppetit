using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using StaticData;

namespace BonAppetitManagerApp.Pages.DashboardComponents.MenuSelectionsComponents;

[Authorize(Roles = Role.Manager)]
public partial class RestaurantComponentsSelections
{
    [Parameter] public List<string> TopMenuList { get; set; }
    private string Selection { get; set; } = "Restaurant Information";

    private Task MenuSelectionTask(string selection)
    {
        Selection = selection;
        Console.WriteLine(Selection);
        return Task.CompletedTask;
    }
}