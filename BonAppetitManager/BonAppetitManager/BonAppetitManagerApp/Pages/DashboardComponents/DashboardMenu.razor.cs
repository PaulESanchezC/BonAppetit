using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using StaticData;

namespace BonAppetitManagerApp.Pages.DashboardComponents;

[Authorize(Roles = Role.Manager)]
public partial class DashboardMenu
{
    [Parameter]
    public EventCallback<string> MenuSelectionCallback { get; set; }

    protected async Task DashboardMenuSelectEvent(int menuSelected)
    {
        switch (menuSelected)
        {
            default:
                await MenuSelectionCallback.InvokeAsync("Analytics");
                break;
            case 2:
                await MenuSelectionCallback.InvokeAsync("Restaurant");
                break;
            case 3:
                await MenuSelectionCallback.InvokeAsync("Tables");
                break;
            case 4:
                await MenuSelectionCallback.InvokeAsync("Reservations");
                break;
            case 5:
                await MenuSelectionCallback.InvokeAsync("Menus");
                break;
            case 6:
                await MenuSelectionCallback.InvokeAsync("Coupons");
                break;
        }
    }
}