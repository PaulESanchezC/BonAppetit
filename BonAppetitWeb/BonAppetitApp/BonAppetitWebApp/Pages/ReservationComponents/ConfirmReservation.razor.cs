using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Models.ReservationModels;
using Models.RestaurantModels;
using Models.TableModels;
using Services.ReservationServices;
using Services.RestaurantServices;
using Services.TableServices;

namespace BonAppetitWebApp.Pages.ReservationComponents;

[AllowAnonymous]
public partial class ConfirmReservation
{
    #region Dependencies
    [Parameter]
    public string RestaurantId { get; set; }
    [Parameter]
    public string TableId { get; set; }
    [Parameter]
    public string DateOfRequest { get; set; }
    [Parameter]
    public int ReservationTime { get; set; }
    [Inject]
    private IReservationServices _reservationServices { get; set; }
    [Inject]
    private IRestaurantService _restaurantService { get; set; }
    [Inject]
    private ITableService _tableService { get; set; }
    [Inject]
    private NavigationManager _navigation { get; set; }
    #endregion

    private ReservationCreateVm Reservation { get; set; } = new();
    private Restaurant Restaurant { get; set; } = new();
    private Table Table { get; set; } = new();

    protected override async Task OnInitializedAsync()
    {
        Reservation.RestaurantId = RestaurantId;
        Reservation.TableId = TableId;
        Reservation.DateOfReservation = DateTime.Parse(DateOfRequest);
        Reservation.StartTime = ReservationTime;

        await GetRestaurantInformationAsync();
        await GetTableInformationAsync();
    }

    private async Task MakeReservation()
    {
        if (string.IsNullOrEmpty(Reservation.ApplicationUserId))
            Reservation.ApplicationUserId = string.Empty;

        Reservation.PaymentTransaction = "here the payment service should execute and give back a transaction number!";

        Reservation.DateOfReservation = DateTime.Parse(DateOfRequest);
        var request = await _reservationServices.MakeReservationAsync(Reservation);
        if (request.IsSuccessful)
            _navigation.NavigateTo("/ReservationConfirmed");
    }


    private async Task GetRestaurantInformationAsync()
    {
        var request = await _restaurantService.GetSingleRestaurantAsync(RestaurantId);
        if (request.IsSuccessful)
            Restaurant = request.ResponseObject!.FirstOrDefault()!;
    }

    private async Task GetTableInformationAsync()
    {
        var request = await _tableService.GetSingleTableAsync(TableId);
        if (request.IsSuccessful)
            Table = request.ResponseObject!.FirstOrDefault()!;
    }
}