using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.ScheduleModels;

namespace Data.FluentApis;

public class ScheduleFluentApi : IEntityTypeConfiguration<ScheduleBase>
{
    public void Configure(EntityTypeBuilder<ScheduleBase> builder)
    {
        builder.HasKey(k => k.ScheduleId);
        builder.Property(k => k.ScheduleId).HasDefaultValue("NEWID()");

        builder.Property(p => p.Sunday).HasDefaultValue(false);
        builder.Property(p => p.SundayOpenTime).HasDefaultValue(12);
        builder.Property(p => p.SundayCloseTime).HasDefaultValue(22);
        builder.Property(p => p.Monday).HasDefaultValue(false);
        builder.Property(p => p.MondayOpenTime).HasDefaultValue(12);
        builder.Property(p => p.MondayCloseTime).HasDefaultValue(22);
        builder.Property(p => p.Tuesday).HasDefaultValue(false);
        builder.Property(p => p.TuesdayOpenTime).HasDefaultValue(12);
        builder.Property(p => p.TuesdayCloseTime).HasDefaultValue(22);
        builder.Property(p => p.Wednesday).HasDefaultValue(false);
        builder.Property(p => p.WednesdayOpenTime).HasDefaultValue(12);
        builder.Property(p => p.WednesdayCloseTime).HasDefaultValue(22);
        builder.Property(p => p.Thursday).HasDefaultValue(false);
        builder.Property(p => p.ThursdayOpenTime).HasDefaultValue(12);
        builder.Property(p => p.ThursdayCloseTime).HasDefaultValue(22);
        builder.Property(p => p.Friday).HasDefaultValue(false);
        builder.Property(p => p.FridayOpenTime).HasDefaultValue(12);
        builder.Property(p => p.FridayCloseTime).HasDefaultValue(22);
        builder.Property(p => p.Saturday).HasDefaultValue(false);
        builder.Property(p => p.SaturdayOpenTime).HasDefaultValue(12);
        builder.Property(p => p.SaturdayCloseTime).HasDefaultValue(22);

        builder.Property(p => p.DateCreated);
    }
}