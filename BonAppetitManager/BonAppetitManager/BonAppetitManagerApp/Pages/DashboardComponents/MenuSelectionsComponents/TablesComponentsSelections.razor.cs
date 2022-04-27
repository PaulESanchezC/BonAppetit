using Microsoft.AspNetCore.Components;

namespace BonAppetitManagerApp.Pages.DashboardComponents.MenuSelectionsComponents;

public partial class TablesComponentsSelections
{
    [Parameter] public List<string> TopMenuList { get; set; } = new();
    [Parameter] public string Selection { get; set; }

    private void MenuSelection(string selection)
    {
        Selection = selection;
    }

    protected override void OnInitialized()
    {
        if (string.IsNullOrEmpty(Selection) || Selection != "Tables Information" || Selection != "Add Table")
            Selection = "Tables Information";
    }
}