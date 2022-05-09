using AutoMapper;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using Models.ApplicationUserModels;
using Models.CouponPaymentModels;
using Models.CouponTypeModels;
using Models.PaymentModels;
using Models.ReservationModels;
using Models.RestaurantModels;
using Models.StripeSessionModels;
using Models.TableModels;
using Models.ViewModels;
using Services.CouponServices;
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
    [Inject] private ICouponServices _couponServices { get; set; }
    [Inject] private IJSRuntime _js { get; set; }
    [Inject] private NavigationManager _navigationManager { get; set; }
    [Inject] private ILocalStorageService _localStorage { get; set; }
    [Inject] private AuthenticationStateProvider _authStateProvider { get; set; }
    #endregion

    private Restaurant Restaurant { get; set; } = new();
    private Table Table { get; set; } = new();
    private ConfirmReservationVm ConfirmReservationVm { get; set; } = new();
    private ApplicationUser ApplicationUser { get; set; } = new();
    private List<CouponType> Coupons { get; set; } = new();

    protected override async Task OnInitializedAsync()
    {
        await GetApplicationUser();
        BuildConfirmReservationVm();
        await GetRestaurantInformationAsync();
        await GetTableInformationAsync();
        await GetCouponInformationAsync();
    }

    private async Task GetApplicationUser()
    {
        var authState = await _authStateProvider.GetAuthenticationStateAsync();
        if (authState.User.IsInRole(Role.Client) && authState.User.Identity!.IsAuthenticated)
        {
            ApplicationUser.Id = authState.User.FindFirst(claim => claim.Type == "sub")!.Value;
            ApplicationUser.FirstName = authState.User.FindFirst(claim => claim.Type == "prefered_name")!.Value;
            ApplicationUser.LastName = authState.User.FindFirst(claim => claim.Type == "family_name")!.Value;
            ApplicationUser.PhoneNumber = authState.User.FindFirst(claim => claim.Type == "phonenumber")!.Value;
            ApplicationUser.UserName = authState.User.FindFirst(claim => claim.Type == "username")!.Value;
        }
        else
        {
            ApplicationUser.Id = string.Empty;
        }
    }
    private void BuildConfirmReservationVm()
    {
        ConfirmReservationVm.RestaurantId = RestaurantId;
        ConfirmReservationVm.TableId = TableId;
        ConfirmReservationVm.DateOfReservation = DateTime.Parse(DateOfRequest);
        ConfirmReservationVm.StartTime = ReservationTime;

        ConfirmReservationVm.ApplicationUserId = ApplicationUser.Id;
        ConfirmReservationVm.FirstName = ApplicationUser.FirstName;
        ConfirmReservationVm.LastName = ApplicationUser.LastName;
        ConfirmReservationVm.Email = ApplicationUser.UserName;
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
    private async Task GetCouponInformationAsync()
    {
        if (string.IsNullOrEmpty(ApplicationUser.Id))
            return;

        var request = await _couponServices.VerifyRestaurantCouponsForUserAsync(RestaurantId, ApplicationUser.Id);
        if (request.IsSuccessful)
            Coupons = request.ResponseObject!;
    }

    private async Task MakeReservation()
    {
        var stripeSessionCreate = BuildStripeSessionCreateModel();
        var request = await _paymentService.CreatePaymentSessionAsync(stripeSessionCreate);
        if (request.IsSuccessful)
        {
            await BuildAndSavePaymentCreateModel(request.ResponseObject!.FirstOrDefault()!);
            await BuildAndSaveReservationCreateModelAndRestaurantEmail();
            await _js.StripePayment(request.ResponseObject!.Select(resp => resp.SessionId).FirstOrDefault()!);
        }
    }
    private StripeSessionCreate BuildStripeSessionCreateModel()
    {
        var stripeSessionCreate = new StripeSessionCreate
        {
            RestaurantId = ConfirmReservationVm.RestaurantId,
            RestaurantName = Restaurant.RestaurantName,
            RestaurantReservationFee = Restaurant.RestaurantReservationFee,
            TableSeats = Table.AmountOfSeats,
            Coupons = Coupons
        };
        return stripeSessionCreate;
    }
    private async Task BuildAndSavePaymentCreateModel(StripeSession session)
    {
        var couponPayments = new List<CouponPaymentsCreateVm>();
        Coupons.ForEach(coupon => couponPayments.Add(new()
        {
            CouponCode = coupon.CouponCode
        }));

        var paymentCreate = new PaymentCreateVm
        {
            ApplicationUserId = ConfirmReservationVm.ApplicationUserId,
            RestaurantId = RestaurantId,
            TableId = TableId,
            BonAppetitFee = session.BonAppetitFee,
            RestaurantReservationFee = session.RestaurantReservationFee,
            ProvincialTaxes = session.ProvincialTaxes,
            FederalTaxes = session.FederalTaxes,
            Amount = session.Amount,
            SessionId = session.SessionId,
            Coupons = couponPayments
        };
        await _localStorage.SetItemAsync(LocalStorage.PaymentInformationPendingPayment, paymentCreate);
    }
    private async Task BuildAndSaveReservationCreateModelAndRestaurantEmail()
    {
        var reservationCreate = new ReservationCreate
        {
            ApplicationUserId = ConfirmReservationVm.ApplicationUserId,
            DateOfReservation = ConfirmReservationVm.DateOfReservation,
            Email = ConfirmReservationVm.Email,
            FirstName = ConfirmReservationVm.FirstName,
            LastName = ConfirmReservationVm.LastName,
            Phone = ConfirmReservationVm.Phone,
            RestaurantId = RestaurantId,
            StartTime = ConfirmReservationVm.StartTime,
            TableId = TableId,
            PaymentTransaction = ""
        };
        await _localStorage.SetItemAsync(LocalStorage.ReservationCreateInformation, reservationCreate);
        await _localStorage.SetItemAsync(LocalStorage.RestaurantEmail, Restaurant.RestaurantEmail);
        await _localStorage.SetItemAsync(LocalStorage.RestaurantName, Restaurant.RestaurantName);
        await _localStorage.SetItemAsync(LocalStorage.Coupons, Coupons);
    }
}