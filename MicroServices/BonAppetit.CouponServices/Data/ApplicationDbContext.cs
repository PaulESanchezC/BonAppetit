using Microsoft.EntityFrameworkCore;
using Models.CouponModels;

namespace Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    { }

    public DbSet<CouponType> CouponTypes { get; set; }
    public DbSet<RestaurantCoupons> RestaurantCoupons { get; set; }
}