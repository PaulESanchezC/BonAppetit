using Microsoft.AspNetCore.Components;

namespace BonAppetitManagerApp.Pages.DashboardComponents.MenuSelectionsComponents;

public partial class AnalyticComponentsSelections
{
    [Parameter] public List<string> TopMenuList { get; set; }
    private string Selection { get; set; } = "Reservations Analysis";

    private Task MenuSelectionTask(string selection)
    {
        Selection = selection;
        Console.WriteLine(Selection);
        return Task.CompletedTask;
    }
}