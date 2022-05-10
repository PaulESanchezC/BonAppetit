using Microsoft.AspNetCore.Authorization;
using StaticData;

namespace BonAppetitManagerApp.Pages.CouponComponents;

[Authorize(Roles = Role.Manager)]
public partial class CreateCoupon
{

}