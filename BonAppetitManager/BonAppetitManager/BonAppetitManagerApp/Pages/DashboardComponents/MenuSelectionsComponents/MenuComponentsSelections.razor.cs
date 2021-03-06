using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using StaticData;

namespace BonAppetitManagerApp.Pages.DashboardComponents.MenuSelectionsComponents;

[Authorize(Roles= Role.Manager)]
public partial class MenuComponentsSelections
{
    [Parameter] public List<string> TopMenuList { get; set; }
}