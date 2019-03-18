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

        public PharmacyContext(DbContextOptions<PharmacyContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var userItemBuilder = modelBuilder.Entity<User>();
            userItemBuilder.HasKey(x => x.Id);

            var medicamentItemBuilder = modelBuilder.Entity<Medicament>();
            medicamentItemBuilder.HasKey(x => x.Id);
        }
    }
}