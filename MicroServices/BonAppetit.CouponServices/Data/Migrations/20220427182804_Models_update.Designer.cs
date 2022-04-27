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
    [Migration("20220427182804_Models_update")]
    partial class Models_update
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Models.CouponModels.CouponType", b =>
                {
                    b.Property<string>("CouponTypeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("CouponCode")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateDiscontinued")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.HasKey("CouponTypeId");

                    b.ToTable("CouponTypes");
                });

            modelBuilder.Entity("Models.CouponModels.RestaurantCoupons", b =>
                {
                    b.Property<string>("RestaurantCouponsId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CouponTypeId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DateRequested")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("RestaurantId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RestaurantCouponsId");

                    b.HasIndex("CouponTypeId");

                    b.ToTable("RestaurantCoupons");
                });

            modelBuilder.Entity("Models.CouponModels.RestaurantCoupons", b =>
                {
                    b.HasOne("Models.CouponModels.CouponType", "CouponType")
                        .WithMany()
                        .HasForeignKey("CouponTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CouponType");
                });
#pragma warning restore 612, 618
        }
    }
}