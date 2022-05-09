using Microsoft.EntityFrameworkCore;
using Models.CouponPaymentModels;
using Models.PaymentModels;

namespace Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    { }

    public DbSet<PaymentBase> Payments { get; set; }
    public DbSet<CouponPayments> CouponPayments { get; set; }
}