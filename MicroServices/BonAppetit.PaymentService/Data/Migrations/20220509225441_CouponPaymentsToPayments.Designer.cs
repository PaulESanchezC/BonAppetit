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
    [Migration("20220509225441_CouponPaymentsToPayments")]
    partial class CouponPaymentsToPayments
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Models.CouponPaymentModels.CouponPayments", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CouponCode")
                        .HasColumnType("int");

                    b.Property<string>("PaymentBasePaymentId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("PaymentBasePaymentId");

                    b.ToTable("CouponPayments");
                });

            modelBuilder.Entity("Models.PaymentModels.PaymentBase", b =>
                {
                    b.Property<string>("PaymentId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<string>("ApplicationUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("BonAppetitFee")
                        .HasColumnType("float");

                    b.Property<DateTime>("DateOfPayment")
                        .HasColumnType("datetime2");

                    b.Property<double>("FederalTaxes")
                        .HasColumnType("float");

                    b.Property<double>("ProvincialTaxes")
                        .HasColumnType("float");

                    b.Property<string>("RestaurantId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("RestaurantReservationFee")
                        .HasColumnType("float");

                    b.Property<string>("SessionId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TableId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PaymentId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("Models.CouponPaymentModels.CouponPayments", b =>
                {
                    b.HasOne("Models.PaymentModels.PaymentBase", null)
                        .WithMany("Coupons")
                        .HasForeignKey("PaymentBasePaymentId");
                });

            modelBuilder.Entity("Models.PaymentModels.PaymentBase", b =>
                {
                    b.Navigation("Coupons");
                });
#pragma warning restore 612, 618
        }
    }
}