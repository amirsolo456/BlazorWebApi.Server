using BlazorWebApi.Domain.Entities;
using BlazorWebApi.Domain.Entities.Owner;
using BlazorWebApi.Domain.Entities.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWebApi.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OnvanList>().HasData(
            new OnvanList { ID = 0, IDType = 1, Onvan = "مشتری" },
            new OnvanList { ID = 1, IDType = 1, Onvan = "مالک" },
            new OnvanList { ID = 2, IDType = 1, Onvan = "ادمین" }
            );

            modelBuilder.Entity<VillaCategory>()
    .HasKey(vc => new { vc.ID, vc.IDType, vc.CategoryID });

        }

        public DbSet<Villa> tblVillas { get; set; }
        public DbSet<VillaNumber> tblVillaNumbers { get; set; }
        public DbSet<ShoppingCart> tblShoppingCart { get; set; }
        public DbSet<Customer> tblCustomers { get; set; }
        public DbSet<Owners> tblOwners { get; set; }
        public DbSet<Booking> tblBokking { get; set; }
        public DbSet<Admin> tblAdmin { get; set; }
        public DbSet<Messages> tblMessages { get; set; }
        public DbSet<OnvanList> tblOnvanList { get; set; }
        public DbSet<LoginLog> tblLoginLog { get; set; }
        public DbSet<VillaCategory> tblVillaCategory { get; set; }
    }
}
