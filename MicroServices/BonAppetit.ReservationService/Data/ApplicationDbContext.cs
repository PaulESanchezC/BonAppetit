using Microsoft.EntityFrameworkCore;
using Models.ApplicationUserModels;
using Models.ReservationModels;

namespace Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    public DbSet<AnonymousUser> AnonymousUsers { get; set; }
    public DbSet<ReservationBase> Reservations { get; set; }
}