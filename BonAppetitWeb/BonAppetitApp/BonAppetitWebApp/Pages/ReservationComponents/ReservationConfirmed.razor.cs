using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Models.EmailModels;
using Models.PaymentMessageModels;
using Models.PaymentModels;
using Models.ReservationModels;
using Models.ResponseModels;
using Models.RestaurantModels;
using Services.PaymentServices;
using Services.RestaurantServices;
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
        await _localStorage.ClearAsync();
    }

    private async Task ConfirmPaymentAsync()
    {
        var paymentInformation = await _localStorage.GetItemAsync<PaymentCreateVm>(LocalStorage.PaymentInformationPendingPayment);

        var message =  await BuildPaymentMessage();
        var confirmPayment = await _paymentServices.ConfirmPaymentAsync(paymentInformation, message);
        if (confirmPayment.IsSuccessful)
            Request = confirmPayment.IsSuccessful;
    }
    private async Task<PaymentMessage> BuildPaymentMessage()
    {
        var reservationCreate = await _localStorage.GetItemAsync<ReservationCreate>(LocalStorage.ReservationCreateInformation);
        var restaurantEmail = await _localStorage.GetItemAsStringAsync(LocalStorage.RestaurantEmail);

        var emails = new List<Email>
        {
            new()
            {
                Action = "reservation client",
                Recipient = reservationCreate.Email,
                Data=""
            },
            new()
            {
                Action = "reservation manager",
                Recipient = restaurantEmail,
                Data=""
            }
        };
        var paymentMessage = new PaymentMessage
        {
            Emails = emails,
            ReservationCreate = reservationCreate
        };
        return paymentMessage;
    }
}