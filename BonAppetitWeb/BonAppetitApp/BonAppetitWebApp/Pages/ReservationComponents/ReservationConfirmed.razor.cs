using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Models.CouponTypeModels;
using Models.MessageQueueModels.PaymentSuccessMessageModels;
using Models.PaymentModels;
using Models.ReservationModels;
using Services.PaymentServices;
using StaticData;

namespace BonAppetitWebApp.Pages.ReservationComponents;

public partial class ReservationConfirmed
{
    #region Dependencies
    [Inject] private ILocalStorageService _localStorage { get; set; }
    [Inject] private IPaymentService _paymentServices { get; set; }
    #endregion
    public bool Request { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await ConfirmPaymentAsync();
    }

    private async Task ConfirmPaymentAsync()
    {
        var paymentInformation = await _localStorage.GetItemAsync<PaymentCreateVm>(LocalStorage.PaymentInformationPendingPayment);

        var message =  await BuildPaymentMessage(paymentInformation.Coupons);
        var confirmPayment = await _paymentServices.ConfirmPaymentAsync(paymentInformation, message);
        if (confirmPayment.IsSuccessful)
        {
            Request = confirmPayment.IsSuccessful;
        }
    }
    private async Task<PaymentMessage> BuildPaymentMessage(List<CouponType> coupons)
    {
        var reservationCreate = await _localStorage.GetItemAsync<ReservationCreate>(LocalStorage.ReservationCreateInformation);
        var restaurantEmail = await _localStorage.GetItemAsStringAsync(LocalStorage.RestaurantEmail);
        var restaurantName = await _localStorage.GetItemAsStringAsync(LocalStorage.RestaurantName);

        var paymentMessage = new PaymentMessage
        {
            RestaurantEmail = restaurantEmail,
            ReservationCreate = reservationCreate,
            RestaurantName = restaurantName,
            Coupons = coupons
        };
        return paymentMessage;
    }
}