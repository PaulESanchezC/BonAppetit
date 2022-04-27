using Microsoft.AspNetCore.Components;

namespace BonAppetitManagerApp.Pages.DashboardComponents.MenuSelectionsComponents;

public partial class AnalyticComponentsSelections
{
    [Parameter] public List<string> TopMenuList { get; set; }
    [Parameter] public string Selection { get; set; }

    private void MenuSelection(string selection)
    {
        Selection = selection;
    }
    protected override void OnInitialized()
    {
        if (string.IsNullOrEmpty(Selection) || Selection != "Reservations Analysis" || Selection != "Coupon Reservations Analysis" || Selection != "Menus Analysis Researches")
            Selection = "Reservations Analysis";
    }
}