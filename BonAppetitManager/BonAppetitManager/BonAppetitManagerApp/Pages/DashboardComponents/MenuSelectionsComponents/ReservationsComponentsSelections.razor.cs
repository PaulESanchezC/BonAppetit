using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using StaticData;

namespace BonAppetitManagerApp.Pages.DashboardComponents.MenuSelectionsComponents;

[Authorize(Roles = Role.Manager)]
public partial class ReservationsComponentsSelections
{
    [Parameter] public List<string> TopMenuList { get; set; } = new();
    [Parameter] public string Selection { get; set; }

    private void MenuSelection(string selection)
    {
        Selection = selection;
    }

    protected override void OnInitialized()
    {
        if (string.IsNullOrEmpty(Selection) || Selection != "Today's Reservations" || Selection != "Search for Reservation")
            Selection = "Today's Reservations";
    }
}