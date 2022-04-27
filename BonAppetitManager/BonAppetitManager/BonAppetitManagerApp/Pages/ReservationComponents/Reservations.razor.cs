using AutoMapper;
using Blazored.SessionStorage;
using BonAppetitManagerApp.Pages.TablesComponents;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Models.DashboardVm.Reservations;
using Models.NavigationMenuModels;
using Models.ReservationModels;
using Models.TableModels;
using Services.ReservationServices;
using Services.TableServices;
using StaticData;

namespace BonAppetitManagerApp.Pages.ReservationComponents;

[Authorize(Roles = Role.Manager)]
public partial class Reservations
{
    #region Dependencies

    [Inject] private IReservationService _reservationService { get; set; }
    [Inject] private ITableService _tableService { get; set; }
    [Inject] private ISessionStorageService _sessionStorage { get; set; }
    [Inject] private IMapper _mapper { get; set; }

    #endregion

    private List<Reservation>? ReservationsList { get; set; } = new();
    private List<Table>? TablesList { get; set; } = new();
    private List<ReservationVm> ReservationVmsList { get; set; } = new();

    protected override async Task OnInitializedAsync()
    {
        await SetNavigationPropertiesAsync();
        await GetReservationsAsync();
        await GetTablesAsync();
        BuildViewModel();
    }

    private async Task GetReservationsAsync()
    {
        var request = await _reservationService.GetReservationsAsync();
        if (request.IsSuccessful)
            ReservationsList = request.ResponseObject;
    }
    private async Task GetTablesAsync()
    {
        var request = await _tableService.GetRestaurantTables();
        if (request.IsSuccessful)
            TablesList = request.ResponseObject;
    }

    private void BuildViewModel()
    {
        foreach (var rsvp in ReservationsList)
        {
            var table = TablesList!.FirstOrDefault(table => table.TableId == rsvp.TableId);
            var reservationVm = new ReservationVm
            {
                Reservation = rsvp,
                Table = table!
            };
            ReservationVmsList.Add(reservationVm);
        }
    }

    private async Task ReservationDetails()
    {
        Console.WriteLine("not yet implemented");
    }
    private async Task SetNavigationPropertiesAsync()
    {
        await _sessionStorage.SetItemAsync(Storage.NavigationProperties, new NavigationMenu
        {
            DashboardMenuSelection = "Reservations",
            DashboardTopMenuSelection = "Today's Reservations"
        });
    }

};