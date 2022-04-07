using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.TableModels;

namespace Data.FluentApis;

public class TableFluentApi : IEntityTypeConfiguration<TableBase>
{
    public void Configure(EntityTypeBuilder<TableBase> builder)
    {
        builder.HasKey(k => k.TableId);
        builder.Property(k => k.TableId).HasDefaultValue("NEWID()");

        builder.Property(p => p.TableName).IsRequired(false).HasDefaultValue("table name / table number")
            .HasMaxLength(25);
        builder.Property(p => p.FrequencyOfReservation).HasDefaultValue(2);
        builder.Property(p => p.AmountOfSeats).HasDefaultValue(2);
    }
}