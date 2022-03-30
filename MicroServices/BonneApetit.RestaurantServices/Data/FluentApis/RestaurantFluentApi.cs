using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.RestaurantModels;
using Models.ScheduleModels;

namespace Data.FluentApis;

public class RestaurantFluentApi : IEntityTypeConfiguration<RestaurantBase>
{
    public void Configure(EntityTypeBuilder<RestaurantBase> builder)
    {
        builder.HasKey(k => k.RestaurantId);
        builder.Property(k => k.RestaurantId).HasDefaultValue("NEWID()");

        builder.Property(p => p.RestaurantName).HasDefaultValue("restaurant name").IsRequired(false);
        builder.Property(p => p.RestaurantPhone).HasDefaultValue("phone number").IsRequired(false);
        builder.Property(p => p.RestaurantAddress).HasDefaultValue("address").IsRequired(false);
        builder.Property(p => p.RestaurantWebsite).HasDefaultValue("website").IsRequired(false);
        builder.Property(p => p.RestaurantCiy).HasDefaultValue("city").IsRequired(false);
        builder.Property(p => p.RestaurantCuisineType).HasDefaultValue("cuisine type").IsRequired(false);

        builder.HasMany(fk => fk.RestaurantImages).WithOne().OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(fk => fk.RestaurantMenu).WithOne(fk => fk.Restaurant).HasForeignKey(fk => fk.RestaurantId);

        builder.HasMany(fk => fk.RestaurantTables).WithOne(fk=>fk.Restaurant).HasForeignKey(fk=>fk.RestaurantId).OnDelete(DeleteBehavior.Cascade);

        builder.HasOne<ScheduleBase>(fk => fk.RestaurantSchedule).WithOne(fk => fk.Restaurant)
            .HasForeignKey<RestaurantBase>(r => r.ScheduleId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(p => p.DateCreated).HasDefaultValue(DateTime.Now);
        builder.Property(p => p.ZonePopularity).HasDefaultValue(5);
        builder.Property(p => p.IsDeleted).HasDefaultValue(false);
    }
}