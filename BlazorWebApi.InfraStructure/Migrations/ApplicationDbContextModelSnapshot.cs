﻿// <auto-generated />
using System;
using BlazorWebApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BlazorWebApi.InfraStructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BlazorWebApi.Domain.Entities.Admin", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("Access")
                        .HasColumnType("int");

                    b.Property<bool>("CustomerManage")
                        .HasColumnType("bit");

                    b.Property<string>("FLName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("OwnerManage")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SabtDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("tblAdmin");
                });

            modelBuilder.Entity("BlazorWebApi.Domain.Entities.Booking", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<string>("EndDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsReserved")
                        .HasColumnType("bit");

                    b.Property<decimal>("MabKol")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("NumberGuests")
                        .HasColumnType("int");

                    b.Property<int>("PaymentMethod")
                        .HasColumnType("int");

                    b.Property<string>("StartDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VillaID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("tblBokking");
                });

            modelBuilder.Entity("BlazorWebApi.Domain.Entities.Customer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("EmailAddres")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("FLName")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PhNumber")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime?>("SighnUpDate")
                        .HasMaxLength(30)
                        .HasColumnType("datetime2");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.ToTable("tblCustomers");
                });

            modelBuilder.Entity("BlazorWebApi.Domain.Entities.Messages", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("IDGroup")
                        .HasColumnType("int");

                    b.Property<int?>("IDRecieve")
                        .HasColumnType("int");

                    b.Property<int>("IDSend")
                        .HasColumnType("int");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("OnRead")
                        .HasColumnType("bit");

                    b.Property<string>("SabtDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<int?>("TypeRecieve")
                        .HasColumnType("int");

                    b.Property<int?>("VillaID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("tblMessages");
                });

            modelBuilder.Entity("BlazorWebApi.Domain.Entities.Owner.VillaCategory", b =>
                {
                    b.Property<int>("ID")
                        .HasColumnType("int");

                    b.Property<int>("IDType")
                        .HasColumnType("int");

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID", "IDType", "CategoryID");

                    b.ToTable("tblVillaCategory");
                });

            modelBuilder.Entity("BlazorWebApi.Domain.Entities.Owners", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("PhNumber")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("SabtDate")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<double>("Score")
                        .HasColumnType("float");

                    b.HasKey("ID");

                    b.ToTable("tblOwners");
                });

            modelBuilder.Entity("BlazorWebApi.Domain.Entities.Shared.LoginLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("IPAddress")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<bool>("IsCustomer")
                        .HasColumnType("bit");

                    b.Property<bool>("IsLogin")
                        .HasColumnType("bit");

                    b.Property<bool>("IsOwner")
                        .HasColumnType("bit");

                    b.Property<string>("LoginTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LogoutTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("tblLoginLog");
                });

            modelBuilder.Entity("BlazorWebApi.Domain.Entities.Shared.OnvanList", b =>
                {
                    b.Property<int>("ID")
                        .HasColumnType("int");

                    b.Property<int>("IDType")
                        .HasColumnType("int");

                    b.Property<string>("Onvan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("tblOnvanList");

                    b.HasData(
                        new
                        {
                            ID = 0,
                            IDType = 1,
                            Onvan = "مشتری"
                        },
                        new
                        {
                            ID = 1,
                            IDType = 1,
                            Onvan = "مالک"
                        },
                        new
                        {
                            ID = 2,
                            IDType = 1,
                            Onvan = "ادمین"
                        });
                });

            modelBuilder.Entity("BlazorWebApi.Domain.Entities.ShoppingCart", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime?>("CreateDate")
                        .HasMaxLength(50)
                        .HasColumnType("datetime2");

                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<double>("Quantity")
                        .HasColumnType("float");

                    b.Property<DateTime?>("UpdateDate")
                        .HasMaxLength(50)
                        .HasColumnType("datetime2");

                    b.Property<int>("VillaID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CustomerID");

                    b.HasIndex("VillaID");

                    b.ToTable("tblShoppingCart");
                });

            modelBuilder.Entity("BlazorWebApi.Domain.Entities.Villa", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime?>("CreateDate")
                        .HasMaxLength(30)
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("Guestroom")
                        .HasColumnType("bit");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsOffer")
                        .HasColumnType("bit");

                    b.Property<bool>("IsReserved")
                        .HasColumnType("bit");

                    b.Property<bool>("Jacuzzi")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("Occupancy")
                        .HasColumnType("int");

                    b.Property<bool>("Parking")
                        .HasColumnType("bit");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Sqft")
                        .HasColumnType("int");

                    b.Property<bool>("Swimmingpool")
                        .HasColumnType("bit");

                    b.Property<double?>("TakhfifPerAllNights")
                        .HasColumnType("float");

                    b.Property<double?>("TakhfifPerNight")
                        .HasColumnType("float");

                    b.Property<DateTime?>("UpdateDate")
                        .HasMaxLength(30)
                        .HasColumnType("datetime2");

                    b.Property<int?>("VillaCategory1")
                        .HasColumnType("int");

                    b.Property<int?>("VillaCategory2")
                        .HasColumnType("int");

                    b.Property<int?>("VillaCategory3")
                        .HasColumnType("int");

                    b.Property<int?>("VillaCategory4")
                        .HasColumnType("int");

                    b.Property<int?>("VillaCategory5")
                        .HasColumnType("int");

                    b.Property<int?>("VillaType1")
                        .HasColumnType("int");

                    b.Property<int?>("VillaType2")
                        .HasColumnType("int");

                    b.Property<int?>("VillaType3")
                        .HasColumnType("int");

                    b.Property<int?>("VillaType4")
                        .HasColumnType("int");

                    b.Property<int?>("VillaType5")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("tblVillas");
                });

            modelBuilder.Entity("BlazorWebApi.Domain.Entities.VillaNumber", b =>
                {
                    b.Property<int>("Villa_Number")
                        .HasColumnType("int");

                    b.Property<string>("SpecialDetails")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("VillaID")
                        .HasColumnType("int");

                    b.HasKey("Villa_Number");

                    b.HasIndex("VillaID");

                    b.ToTable("tblVillaNumbers");
                });

            modelBuilder.Entity("BlazorWebApi.Domain.Entities.ShoppingCart", b =>
                {
                    b.HasOne("BlazorWebApi.Domain.Entities.Customer", null)
                        .WithMany("ShoppingCarts")
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BlazorWebApi.Domain.Entities.Villa", "villa")
                        .WithMany()
                        .HasForeignKey("VillaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("villa");
                });

            modelBuilder.Entity("BlazorWebApi.Domain.Entities.VillaNumber", b =>
                {
                    b.HasOne("BlazorWebApi.Domain.Entities.Villa", "Villa")
                        .WithMany()
                        .HasForeignKey("VillaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Villa");
                });

            modelBuilder.Entity("BlazorWebApi.Domain.Entities.Customer", b =>
                {
                    b.Navigation("ShoppingCarts");
                });
#pragma warning restore 612, 618
        }
    }
}
