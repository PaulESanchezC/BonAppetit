using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.MenuItemModels;
using Models.MenuModels;

namespace Data.FluentApis;

public class MenuItemFluentApi : IEntityTypeConfiguration<MenuItemsBase>
{
    public void Configure(EntityTypeBuilder<MenuItemsBase> builder)
    {
        builder.HasKey(k => k.ItemId);
        builder.Property(k => k.ItemId).HasDefaultValue("NEWID()");

        builder.Property(p => p.ItemName).IsRequired(false).HasMaxLength(50).HasDefaultValue("menu item name: ");

        builder.Property(p => p.Description).IsRequired(false).HasMaxLength(50)
            .HasDefaultValue("menu item description");

        builder.Property(p => p.CuisineType).IsRequired(false).HasMaxLength(50).HasDefaultValue("cuisine type");

        builder.Property(fk => fk.ImageId).IsRequired();
        builder.HasOne(fk => fk.Image).WithOne().HasForeignKey<MenuItemsBase>(fk => fk.ImageId);

        builder.Property(p => p.DateCreated).HasDefaultValue(DateTime.Now);
        builder.Property(p => p.Public).HasDefaultValue(false);
    }
}