using BlazorWebApi.Domain.Entities;
using BlazorWebApi.Domain.Entities.Admin;
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

        }

        public DbSet<Villa> tblVillas { get; set; }
        public DbSet<VillaNumber> tblVillaNumbers { get; set; }
        public DbSet<ShoppingCart> tblShoppingCart { get; set; }
        public DbSet<Customer> tblCustomers { get; set; }
        public DbSet<Owners> tblOwners { get; set; }
        public DbSet<Booking> tblBokking { get; set; }
        public DbSet<Admin> tblAdmin { get; set; }
        public DbSet<Messages> tblMessages { get; set; }
    }
}
