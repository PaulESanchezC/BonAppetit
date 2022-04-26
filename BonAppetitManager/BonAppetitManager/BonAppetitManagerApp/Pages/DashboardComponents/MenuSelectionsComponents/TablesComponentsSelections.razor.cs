using Microsoft.AspNetCore.Components;

namespace BonAppetitManagerApp.Pages.DashboardComponents.MenuSelectionsComponents;

public partial class TablesComponentsSelections
{
    [Parameter] public List<string> TopMenuList { get; set; } = new();
    [Parameter] public string Selection { get; set; } = "Tables Information";

    private Task MenuSelectionTask(string selection)
    {
        Selection = selection;
        return Task.CompletedTask;
    }

    protected override void OnInitialized()
    {
        if (string.IsNullOrEmpty(Selection))
            Selection = "Tables Information";
    }
}