using Data.FluentApis;
using Microsoft.EntityFrameworkCore;
using Models.ImageModels;
using Models.MenuItemModels;
using Models.MenuModels;
using Models.RestaurantModels;
using Models.ScheduleModels;
using Models.TableModels;

namespace Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    { }

    public DbSet<ImageBase> Images { get; set; }
    public DbSet<MenuBase> Menus { get; set; }
    public DbSet<MenuItemsBase> MenuItems { get; set; }
    public DbSet<RestaurantBase> Restaurants { get; set; }
    public DbSet<ScheduleBase> Schedules { get; set; }
    public DbSet<TableBase> Tables { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new ImageFluentApi());
        modelBuilder.ApplyConfiguration(new MenuFluentApi());
        modelBuilder.ApplyConfiguration(new MenuItemFluentApi());
        modelBuilder.ApplyConfiguration(new RestaurantFluentApi());
        modelBuilder.ApplyConfiguration(new ScheduleFluentApi());
        modelBuilder.ApplyConfiguration(new TableFluentApi());
    }
}