using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.MenuItemModels;
using Models.MenuModels;

namespace Data.FluentApis;

public class MenuFluentApi : IEntityTypeConfiguration<MenuBase>
{
    public void Configure(EntityTypeBuilder<MenuBase> builder)
    {
        builder.HasKey(k => k.MenuId);
        builder.Property(k => k.MenuId).HasDefaultValue("NEWID()");

        builder.Property(p => p.MenuName).HasDefaultValue("menu name");
        builder.Property(p => p.MenuDescription).HasDefaultValue("menu descriptions");

        builder.HasMany(fk => fk.MenuItems).WithOne(fk => fk.Menu).HasForeignKey(fk => fk.MenuId).OnDelete(DeleteBehavior.NoAction);

        builder.Property(p => p.Public).HasDefaultValue(false);
    }
}