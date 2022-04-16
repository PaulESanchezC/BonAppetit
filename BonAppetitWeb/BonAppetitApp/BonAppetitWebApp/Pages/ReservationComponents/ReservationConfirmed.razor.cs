using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Models.EmailModels.EmailDataModels;
using Models.EmailModels.EmailReservationModel;
using Models.EmailModels.RestaurantManager;
using Models.PaymentModels;
using Models.ReservationModels;
using Models.RestaurantModels;
using Services.EmailServices;
using Services.PaymentServices;
using Services.ReservationServices;
using Services.RestaurantServices;
using Services.TableServices;
using StaticData;

namespace BonAppetitWebApp.Pages.ReservationComponents;

public partial class ReservationConfirmed
{
    #region Dependencies
    [Inject] private ILocalStorageService _localStorage { get; set; }
    [Inject] private IReservationServices _reservationServices { get; set; }
    [Inject] private IRestaurantService _restaurantServices { get; set; }
    [Inject] private IPaymentService _paymentServices { get; set; }
    [Inject] private IEmailSender _emailSender { get; set; }
    [Inject] private ITableService _tableService { get; set; }
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
                await GetRestaurantInformationAsync();
                await SendReservationEmailsAsync();
            }
        }
    }

    private async Task GetRestaurantInformationAsync()
    {
        var request = await _restaurantServices.GetSingleRestaurantAsync(PaymentInformation.RestaurantId);
        if (request.IsSuccessful)
            Restaurant = request.ResponseObject!.FirstOrDefault()!;
    }

    private async Task SendReservationEmailsAsync()
    {
        var emailReservation = await EmailReservationBuilderAsync();
        var managers = await GetRestaurantManagersEmailsAsync();
        await _emailSender.ReservationEmailSenderAsync(emailReservation, managers);
    }

    private async Task<EmailReservation> EmailReservationBuilderAsync()
    {
        var emailReservation = new EmailReservation();
        emailReservation.StartTime = Reservation.StartTime;
        emailReservation.OrderId = Reservation.OrderId;
        emailReservation.DateOfReservation = Reservation.DateOfReservation;
        emailReservation.ForHowMany = PaymentInformation.TableSeats;
        emailReservation.RestaurantName = PaymentInformation.RestaurantName;

        var tableRequest = await _tableService.GetSingleTableAsync(PaymentInformation.TableId);
        if (tableRequest.IsSuccessful)
            emailReservation.TableName = tableRequest.ResponseObject!.Select(table => table.TableName).FirstOrDefault()!;

        var client = new EmailClient();
        client.UserFirstName = Reservation.FirstName;
        client.UserLastName = Reservation.LastName;
        client.UserPhone = Reservation.Phone;
        client.UserEmail = Reservation.Email;
        emailReservation.Client = client;

        return emailReservation;
    }

    //TODO: Change when identity server is finished
    private Task<List<string>> GetRestaurantManagersEmailsAsync()
    {
        var managers = new List<string>
        {
            "paulsanchezco@gmail.com",
            "paulesanchezc@outlook.com",
            "paulsanchezco1@gmail.com",
        };
        return Task.FromResult(managers);
    }
}