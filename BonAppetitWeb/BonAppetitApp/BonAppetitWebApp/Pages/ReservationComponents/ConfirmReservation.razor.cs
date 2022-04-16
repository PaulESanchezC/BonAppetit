using AutoMapper;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Models.PaymentModels;
using Models.ReservationModels;
using Models.RestaurantModels;
using Models.TableModels;
using Models.ViewModels;
using Services.JsRuntimeServices;
using Services.PaymentServices;
using Services.RestaurantServices;
using Services.TableServices;
using StaticData;

namespace BonAppetitWebApp.Pages.ReservationComponents;

[AllowAnonymous]
public partial class ConfirmReservation
{
    #region Dependencies
    [Parameter] public string RestaurantId { get; set; }
    [Parameter] public string TableId { get; set; }
    [Parameter] public string DateOfRequest { get; set; }
    [Parameter] public double ReservationTime { get; set; }
    [Inject] private IRestaurantService _restaurantService { get; set; }
    [Inject] private ITableService _tableService { get; set; }
    [Inject] private IPaymentService _paymentService { get; set; }
    [Inject] private IMapper _mapper { get; set; }
    [Inject] private IJSRuntime _js { get; set; }
    [Inject] private NavigationManager _navigationManager { get; set; }
    [Inject] private ILocalStorageService _localStorage { get; set; }
    #endregion

    private PaymentCreateVm PaymentInformation { get; set; } = new();
    private ReservationCreateVm Reservation { get; set; } = new();
    private Restaurant Restaurant { get; set; } = new();
    private Table Table { get; set; } = new();
    private ConfirmReservationVm ConfirmReservationVm { get; set; } = new();

    protected override async Task OnInitializedAsync()
    {
        ConfirmReservationVm.RestaurantId = RestaurantId;
        ConfirmReservationVm.TableId = TableId;
        ConfirmReservationVm.DateOfReservation = DateTime.Parse(DateOfRequest);
        ConfirmReservationVm.StartTime = ReservationTime;

        await GetRestaurantInformationAsync();
        await GetTableInformationAsync();
    }

    private async Task MakeReservation()
    {
        Reservation = _mapper.Map<ReservationCreateVm>(ConfirmReservationVm);
        if (string.IsNullOrEmpty(Reservation.ApplicationUserId))
        {
            Reservation.ApplicationUserId = string.Empty;
            PaymentInformation.ApplicationUserId = string.Empty;
        }
        Reservation.DateOfReservation = DateTime.Parse(DateOfRequest);
        await _localStorage.SetItemAsync(LocalStorage.ReservationPendingPayment, Reservation);

        PaymentInformation.RestaurantId = RestaurantId;
        PaymentInformation.RestaurantName = Restaurant.RestaurantName;
        PaymentInformation.TableId = TableId;
        PaymentInformation.TableSeats = Table.AmountOfSeats;

        var request = await _paymentService.CreatePaymentSessionAsync(PaymentInformation);
        if (request.IsSuccessful)
            await _localStorage.SetItemAsync(LocalStorage.PaymentInformationPendingPayment,
                request.ResponseObject!.FirstOrDefault());

        var sessionId = request.ResponseObject!.Select(resp => resp.PaymentSessionId).FirstOrDefault();
        await _js.StripePayment(sessionId!);
    }

    private async Task GetRestaurantInformationAsync()
    {
        var request = await _restaurantService.GetSingleRestaurantAsync(RestaurantId);
        if (!request.IsSuccessful)
            _navigationManager.NavigateTo($"/RestaurantDetails/{RestaurantId}");

        Restaurant = request.ResponseObject!.FirstOrDefault()!;
    }

    private async Task GetTableInformationAsync()
    {
        var request = await _tableService.GetSingleTableAsync(TableId);
        if (!request.IsSuccessful)
            _navigationManager.NavigateTo($"/RestaurantDetails/{RestaurantId}");

        Table = request.ResponseObject!.FirstOrDefault()!;
    }
}