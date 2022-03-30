using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.ImageModels;

namespace Data.FluentApis;

public class ImageFluentApi : IEntityTypeConfiguration<ImageBase>
{
    public void Configure(EntityTypeBuilder<ImageBase> builder)
    {
        builder.HasKey(k => k.ImageId);
        builder.Property(k => k.ImageId).HasDefaultValue("NEWID()");
        builder.Property(i => i.DateCreated).HasDefaultValue(DateTime.Now);
        builder.Property(i => i.ImageIndex).HasDefaultValue(0);
        builder.Property(i => i.Description).HasMaxLength(80).HasDefaultValue("image description").IsRequired(false);
    }
}