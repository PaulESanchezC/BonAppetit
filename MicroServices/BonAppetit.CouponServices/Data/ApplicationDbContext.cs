using Microsoft.EntityFrameworkCore;
using Models.CouponActivity;
using Models.CouponTypeModels;
using Models.RestaurantCoupons;

namespace Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    { }

    public DbSet<CouponType> CouponTypes { get; set; }
    public DbSet<RestaurantCoupons> RestaurantCoupons { get; set; }
    public DbSet<CouponActivity> CouponActivities { get; set; }
}