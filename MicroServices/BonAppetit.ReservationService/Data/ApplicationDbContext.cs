using Microsoft.EntityFrameworkCore;
using Models.ReservationModels;

namespace Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<ReservationBase> Reservations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ReservationBase>().Property(p => p.OrderId).ValueGeneratedOnAdd();

        base.OnModelCreating(modelBuilder);
    }
}