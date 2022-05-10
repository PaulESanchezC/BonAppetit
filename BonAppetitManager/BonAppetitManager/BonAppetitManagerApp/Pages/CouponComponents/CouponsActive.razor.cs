using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Models.RestaurantCoupons;
using Services.CouponServices;
using StaticData;

namespace BonAppetitManagerApp.Pages.CouponComponents;

[Authorize(Roles = Role.Manager)]
public partial class CouponsActive
{
    #region Dependecies

    [Inject] private ICouponService _couponService { get; set; }

    #endregion

    private List<RestaurantCoupons>? RestaurantCoupons { get; set; } = new();

    protected override async Task OnInitializedAsync()
    {
        await GetRestaurantCouponsAsync();
    }

    private async Task GetRestaurantCouponsAsync()
    {
        var request = await _couponService.GetRestaurantCoupons();
        RestaurantCoupons = request.IsSuccessful! ? request.ResponseObject! : null;
    }
}