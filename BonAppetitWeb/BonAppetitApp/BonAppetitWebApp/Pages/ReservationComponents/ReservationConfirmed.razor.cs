using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Models.PaymentModels;
using Models.ReservationModels;
using Models.RestaurantModels;
using Services.PaymentServices;
using Services.ReservationServices;
using Services.RestaurantServices;
using StaticData;

namespace BonAppetitWebApp.Pages.ReservationComponents;

public partial class ReservationConfirmed
{
    #region Dependencies
    [Inject] private ILocalStorageService _localStorage { get; set; }
    [Inject] private IReservationServices _reservationServices { get; set; }
    [Inject] private IRestaurantService _restaurantServices { get; set; }
    [Inject] private IPaymentService _paymentServices { get; set; }
    #endregion

    private Payment PaymentInformation { get; set; } = new();
    private Restaurant Restaurant { get; set; } = new();
    private ReservationCreateVm ReservationCreate { get; set; } = new();
    private Reservation Reservation { get; set; } = new();

    protected override async Task OnInitializedAsync()
    {
        ReservationCreate = await _localStorage.GetItemAsync<ReservationCreateVm>(LocalStorage.ReservationPendingPayment);
        PaymentInformation = await _localStorage.GetItemAsync<Payment>(LocalStorage.PaymentInformationPendingPayment);
        await ConfirmPaymentAndMakeReservationAsync();
    }

    private async Task ConfirmPaymentAndMakeReservationAsync()
    {
        var confirmPayment = await _paymentServices.ConfirmPaymentAsync(PaymentInformation);

        if (confirmPayment.IsSuccessful)
        {
            ReservationCreate.PaymentTransaction = confirmPayment.ResponseObject!.FirstOrDefault()!.PaymentId;
            var reservationRequest = await _reservationServices.MakeReservationAsync(ReservationCreate);
            if (reservationRequest.IsSuccessful)
            {
                Reservation = reservationRequest.ResponseObject!.FirstOrDefault()!;
                await GetRestaurantInformation();
            }
        }
    }

    private async Task GetRestaurantInformation()
    {
        var request = await _restaurantServices.GetSingleRestaurantAsync(PaymentInformation.RestaurantId);
        if (request.IsSuccessful)
            Restaurant = request.ResponseObject!.FirstOrDefault()!;
    }
}