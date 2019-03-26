using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Pharmacy.Core.Models;

namespace Pharmacy.Infrastructure.EF
{
    public class PharmacyContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<PrescriptionElement> PrescriptionElements { get; set; }

        public PharmacyContext(DbContextOptions<PharmacyContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var userItemBuilder = modelBuilder.Entity<User>();
            userItemBuilder.HasKey(x => x.Id);

            var medicamentItemBuilder = modelBuilder.Entity<Medicament>();
            medicamentItemBuilder.HasKey(x => x.Id);

            var prescriptionItemBuilder = modelBuilder.Entity<Prescription>();
            prescriptionItemBuilder.HasKey(x => x.Id);

            var prescriptionElementItemBuilder = modelBuilder.Entity<PrescriptionElement>();
            prescriptionElementItemBuilder.HasKey(x => new {x.MedicamentId, x.PrescriptionId});

            prescriptionElementItemBuilder
                .HasOne(x => x.Medicament)
                .WithMany(x => x.PrescriptionElements)
                .HasForeignKey(x => x.MedicamentId);

            prescriptionElementItemBuilder
                .HasOne(x => x.Prescription)
                .WithMany(x => x.Elements)
                .HasForeignKey(x => x.PrescriptionId);
        }
    }
}