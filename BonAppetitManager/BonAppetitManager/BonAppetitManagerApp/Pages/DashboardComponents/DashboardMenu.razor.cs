using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Models.NavigationMenuModels;
using StaticData;

namespace BonAppetitManagerApp.Pages.DashboardComponents;

[Authorize(Roles = Role.Manager)]
public partial class DashboardMenu
{
    [Parameter]
    public EventCallback<NavigationMenu> MenuSelectionCallback { get; set; }

    protected async Task DashboardMenuSelectEvent(int menuSelected)
    {
        var navigationProperties = new NavigationMenu();
        switch (menuSelected)
        {
            default:
                navigationProperties = new()
                    { DashboardMenuSelection = "Analytics", DashboardTopMenuSelection = "Reservations Analysis" };
                await MenuSelectionCallback.InvokeAsync(navigationProperties);
                break;
            case 2:
                navigationProperties = new()
                    { DashboardMenuSelection = "Restaurant", DashboardTopMenuSelection = "Restaurant Information" };
                await MenuSelectionCallback.InvokeAsync(navigationProperties);
                break;
            case 3:
                navigationProperties = new()
                    { DashboardMenuSelection = "Tables", DashboardTopMenuSelection = "Tables Information" };
                await MenuSelectionCallback.InvokeAsync(navigationProperties);
                break;
            case 4:
                navigationProperties = new()
                    { DashboardMenuSelection = "Reservations", DashboardTopMenuSelection = "Today's Reservations" };
                await MenuSelectionCallback.InvokeAsync(navigationProperties);
                break;
            case 5:
                navigationProperties = new()
                    { DashboardMenuSelection = "Menus", DashboardTopMenuSelection = "Active Menus" };
                await MenuSelectionCallback.InvokeAsync(navigationProperties);
                break;
            case 6:
                navigationProperties = new()
                    { DashboardMenuSelection = "Coupons", DashboardTopMenuSelection = "Coupons Active" };
                await MenuSelectionCallback.InvokeAsync(navigationProperties);
                break;
        }
    }
}