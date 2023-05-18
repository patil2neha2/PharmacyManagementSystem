﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PharmacyManagementSystem.Data;

#nullable disable

namespace PharmacyManagementSystem.Migrations
{
    [DbContext(typeof(PharmacyManagementSystemContext))]
    [Migration("20230518060154_s")]
    partial class s
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PharmacyManagementSystem.Models.Drug", b =>
                {
                    b.Property<int>("DrugId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DrugId"));

                    b.Property<string>("DrugName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("SupplierId")
                        .HasColumnType("int");

                    b.HasKey("DrugId");

                    b.HasIndex("SupplierId");

                    b.ToTable("Drugs");
                });

            modelBuilder.Entity("PharmacyManagementSystem.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"));

                    b.Property<int?>("DrugId")
                        .HasColumnType("int");

                    b.Property<int>("OrderNo")
                        .HasColumnType("int");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("pickupDate")
                        .HasColumnType("datetime2");

                    b.HasKey("OrderId");

                    b.HasIndex("DrugId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("PharmacyManagementSystem.Models.OrderDetail", b =>
                {
                    b.Property<int>("OrderDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderDetailId"));

                    b.Property<int>("DrugId")
                        .HasColumnType("int");

                    b.Property<int>("DrugQuantity")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<decimal>("subTotal")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("OrderDetailId");

                    b.HasIndex("DrugId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("PharmacyManagementSystem.Models.Sale", b =>
                {
                    b.Property<int>("SaleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SaleId"));

                    b.Property<int>("DrugId")
                        .HasColumnType("int");

                    b.Property<int>("QuantitySold")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("SaleId");

                    b.HasIndex("DrugId");

                    b.ToTable("Sales");
                });

            modelBuilder.Entity("PharmacyManagementSystem.Models.Supplier", b =>
                {
                    b.Property<int>("SupplierId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SupplierId"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contact")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SupplierEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SupplierName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SupplierId");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("PharmacyManagementSystem.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Contact")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isAdmin")
                        .HasColumnType("bit");

                    b.Property<bool>("isDoctor")
                        .HasColumnType("bit");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PharmacyManagementSystem.Models.Drug", b =>
                {
                    b.HasOne("PharmacyManagementSystem.Models.Supplier", "Supplier")
                        .WithMany("Drug")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("PharmacyManagementSystem.Models.Order", b =>
                {
                    b.HasOne("PharmacyManagementSystem.Models.Drug", null)
                        .WithMany("Orders")
                        .HasForeignKey("DrugId");

                    b.HasOne("PharmacyManagementSystem.Models.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("PharmacyManagementSystem.Models.OrderDetail", b =>
                {
                    b.HasOne("PharmacyManagementSystem.Models.Drug", "Drug")
                        .WithMany()
                        .HasForeignKey("DrugId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PharmacyManagementSystem.Models.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Drug");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("PharmacyManagementSystem.Models.Sale", b =>
                {
                    b.HasOne("PharmacyManagementSystem.Models.Drug", "Drug")
                        .WithMany()
                        .HasForeignKey("DrugId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Drug");
                });

            modelBuilder.Entity("PharmacyManagementSystem.Models.Drug", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("PharmacyManagementSystem.Models.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("PharmacyManagementSystem.Models.Supplier", b =>
                {
                    b.Navigation("Drug");
                });

            modelBuilder.Entity("PharmacyManagementSystem.Models.User", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
