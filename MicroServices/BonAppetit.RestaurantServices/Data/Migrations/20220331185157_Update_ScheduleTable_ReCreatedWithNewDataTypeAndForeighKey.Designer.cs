﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220331185157_Update_ScheduleTable_ReCreatedWithNewDataTypeAndForeighKey")]
    partial class Update_ScheduleTable_ReCreatedWithNewDataTypeAndForeighKey
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Models.ImageModels.ImageBase", b =>
                {
                    b.Property<string>("ImageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)")
                        .HasDefaultValue("NEWID()");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2022, 3, 31, 14, 51, 57, 283, DateTimeKind.Local).AddTicks(1211));

                    b.Property<string>("Description")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)")
                        .HasDefaultValue("image description");

                    b.Property<byte[]>("ImageBytes")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("ImageIndex")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<string>("RestaurantBaseRestaurantId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ImageId");

                    b.HasIndex("RestaurantBaseRestaurantId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("Models.MenuItemModels.MenuItemsBase", b =>
                {
                    b.Property<string>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)")
                        .HasDefaultValue("NEWID()");

                    b.Property<string>("CuisineType")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasDefaultValue("cuisine type");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2022, 3, 31, 14, 51, 57, 284, DateTimeKind.Local).AddTicks(3286));

                    b.Property<string>("Description")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasDefaultValue("menu item description");

                    b.Property<string>("ImageId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ItemName")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasDefaultValue("menu item name: ");

                    b.Property<string>("MenuBaseMenuId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Public")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.HasKey("ItemId");

                    b.HasIndex("ImageId")
                        .IsUnique();

                    b.HasIndex("MenuBaseMenuId");

                    b.ToTable("MenuItems");
                });

            modelBuilder.Entity("Models.MenuModels.MenuBase", b =>
                {
                    b.Property<string>("MenuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)")
                        .HasDefaultValue("NEWID()");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2022, 3, 31, 14, 51, 57, 283, DateTimeKind.Local).AddTicks(9884));

                    b.Property<string>("MenuDescription")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("menu descriptions");

                    b.Property<string>("MenuName")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("menu name");

                    b.Property<bool>("Public")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("RestaurantId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("MenuId");

                    b.HasIndex("RestaurantId");

                    b.ToTable("Menus");
                });

            modelBuilder.Entity("Models.RestaurantModels.RestaurantBase", b =>
                {
                    b.Property<string>("RestaurantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)")
                        .HasDefaultValue("NEWID()");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2022, 3, 31, 14, 51, 57, 286, DateTimeKind.Local).AddTicks(4685));

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("RestaurantAddress")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("address");

                    b.Property<string>("RestaurantCiy")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("city");

                    b.Property<string>("RestaurantCuisineType")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("cuisine type");

                    b.Property<string>("RestaurantName")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("restaurant name");

                    b.Property<string>("RestaurantPhone")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("phone number");

                    b.Property<string>("RestaurantWebsite")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("website");

                    b.Property<string>("ScheduleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ZonePopularity")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(5);

                    b.HasKey("RestaurantId");

                    b.ToTable("Restaurants");
                });

            modelBuilder.Entity("Models.ScheduleModels.ScheduleBase", b =>
                {
                    b.Property<string>("ScheduleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)")
                        .HasDefaultValue("NEWID()");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2022, 3, 31, 14, 51, 57, 287, DateTimeKind.Local).AddTicks(272));

                    b.Property<bool>("Friday")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<int>("FridayCloseTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(22);

                    b.Property<int>("FridayOpenTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(12);

                    b.Property<bool>("Monday")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<int>("MondayCloseTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(22);

                    b.Property<int>("MondayOpenTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(12);

                    b.Property<string>("RestaurantId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Saturday")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<int>("SaturdayCloseTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(22);

                    b.Property<int>("SaturdayOpenTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(12);

                    b.Property<bool>("Sunday")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<int>("SundayCloseTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(22);

                    b.Property<int>("SundayOpenTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(12);

                    b.Property<bool>("Thursday")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<int>("ThursdayCloseTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(22);

                    b.Property<int>("ThursdayOpenTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(12);

                    b.Property<bool>("Tuesday")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<int>("TuesdayCloseTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(22);

                    b.Property<int>("TuesdayOpenTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(12);

                    b.Property<bool>("Wednesday")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<int>("WednesdayCloseTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(22);

                    b.Property<int>("WednesdayOpenTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(12);

                    b.HasKey("ScheduleId");

                    b.HasIndex("RestaurantId")
                        .IsUnique();

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("Models.TableModels.TableBase", b =>
                {
                    b.Property<string>("TableId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)")
                        .HasDefaultValue("NEWID()");

                    b.Property<int>("AmountOfSeats")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(2);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<int>("FrequencyOfReservation")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(2);

                    b.Property<double>("HoursOpenForReservation")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("float")
                        .HasDefaultValue(10.0);

                    b.Property<string>("RestaurantId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TableName")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)")
                        .HasDefaultValue("table name / table number");

                    b.HasKey("TableId");

                    b.HasIndex("RestaurantId");

                    b.ToTable("Tables");
                });

            modelBuilder.Entity("Models.ImageModels.ImageBase", b =>
                {
                    b.HasOne("Models.RestaurantModels.RestaurantBase", null)
                        .WithMany("RestaurantImages")
                        .HasForeignKey("RestaurantBaseRestaurantId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Models.MenuItemModels.MenuItemsBase", b =>
                {
                    b.HasOne("Models.ImageModels.ImageBase", "Image")
                        .WithOne()
                        .HasForeignKey("Models.MenuItemModels.MenuItemsBase", "ImageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.MenuModels.MenuBase", null)
                        .WithMany("MenuItems")
                        .HasForeignKey("MenuBaseMenuId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Image");
                });

            modelBuilder.Entity("Models.MenuModels.MenuBase", b =>
                {
                    b.HasOne("Models.RestaurantModels.RestaurantBase", "Restaurant")
                        .WithMany("RestaurantMenu")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("Models.ScheduleModels.ScheduleBase", b =>
                {
                    b.HasOne("Models.RestaurantModels.RestaurantBase", "Restaurant")
                        .WithOne("RestaurantSchedule")
                        .HasForeignKey("Models.ScheduleModels.ScheduleBase", "RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("Models.TableModels.TableBase", b =>
                {
                    b.HasOne("Models.RestaurantModels.RestaurantBase", "Restaurant")
                        .WithMany("RestaurantTables")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("Models.MenuModels.MenuBase", b =>
                {
                    b.Navigation("MenuItems");
                });

            modelBuilder.Entity("Models.RestaurantModels.RestaurantBase", b =>
                {
                    b.Navigation("RestaurantImages");

                    b.Navigation("RestaurantMenu");

                    b.Navigation("RestaurantSchedule")
                        .IsRequired();

                    b.Navigation("RestaurantTables");
                });
#pragma warning restore 612, 618
        }
    }
}
