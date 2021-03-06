﻿using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Pharmacy.Core.Models;
using Pharmacy.Infrastructure.Services.Implementations;

namespace Pharmacy.Infrastructure.EF
{
    public class PharmacyContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<PrescriptionElement> PrescriptionElements { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderElement> OrderElements { get; set; }
        public DbSet<Sale> Sales{ get; set; }
        public DbSet<SaleElement> SaleElements { get; set; }

        public PharmacyContext(DbContextOptions<PharmacyContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var user = CreateFirstUser();
            modelBuilder.Entity<User>().HasData(
                user);


            var userItemBuilder = modelBuilder.Entity<User>();
            userItemBuilder.HasKey(x => x.Id);

            var medicamentItemBuilder = modelBuilder.Entity<Medicament>();
            medicamentItemBuilder.HasKey(x => x.EanCode);

            var saleItemBuilder = modelBuilder.Entity<Sale>();
            saleItemBuilder.HasKey(x => x.Id);

            saleItemBuilder
                .HasMany(x => x.Prescriptions);

            var prescriptionItemBuilder = modelBuilder.Entity<Prescription>();
            prescriptionItemBuilder.HasKey(x => x.Id);

            var orderItemBuilder = modelBuilder.Entity<Order>();
            orderItemBuilder.HasKey(x => x.Id);

            var orderElementItemBuilder = modelBuilder.Entity<OrderElement>();
            orderElementItemBuilder.HasKey(x => new { x.EanCode, x.OrderId });

            orderElementItemBuilder
                .HasOne(x => x.Medicament)
                .WithMany(x => x.OrderElements)
                .HasForeignKey(x => x.EanCode);

            orderElementItemBuilder
                .HasOne(x => x.Order)
                .WithMany(x => x.Elements)
                .HasForeignKey(x => x.OrderId);

            var prescriptionElementItemBuilder = modelBuilder.Entity<PrescriptionElement>();
            prescriptionElementItemBuilder.HasKey(x => new {x.EanCode, x.PrescriptionId});

            prescriptionElementItemBuilder
                .HasOne(x => x.Medicament)
                .WithMany(x => x.PrescriptionElements)
                .HasForeignKey(x => x.EanCode);

            prescriptionElementItemBuilder
                .HasOne(x => x.Prescription)
                .WithMany(x => x.Elements)
                .HasForeignKey(x => x.PrescriptionId);

            var saleElementItemBuilder = modelBuilder.Entity<SaleElement>();
            saleElementItemBuilder.HasKey(x => new { x.EanCode, x.SaleId });

            saleElementItemBuilder
                .HasOne(x => x.Medicament)
                .WithMany(x => x.SaleElements)
                .HasForeignKey(x => x.EanCode);

            saleElementItemBuilder
                .HasOne(x => x.Sale)
                .WithMany(x => x.MedicamentsSoldWithoutPrescription)
                .HasForeignKey(x => x.SaleId);
        }


        private User CreateFirstUser()
        {
            var encrypter = new Encrypter();
            var salt = encrypter.GetSalt("SuperSecurePassword");
            var hash = encrypter.GetHash("SuperSecurePassword", salt);
            var user = new User(Guid.NewGuid(), "zdzislaw.grzybowski@gmail.com", "zdzislaw.grzybowski@gmail.com", "Zdzisław Grzybowski",
                "Admin", "Lekarz psychiatra", hash, salt);

            return user;
        }
    }
}