using Microsoft.AspNetCore.Components;

namespace BonAppetitManagerApp.Pages.DashboardComponents.MenuSelectionsComponents;

public partial class AnalyticComponentsSelections
{
    [Parameter] public List<string> TopMenuList { get; set; }
}