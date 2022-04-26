using Microsoft.AspNetCore.Components;

namespace BonAppetitManagerApp.Pages.DashboardComponents.MenuSelectionsComponents;

public partial class TablesComponentsSelections
{
    [Parameter] public List<string> TopMenuList { get; set; }
}