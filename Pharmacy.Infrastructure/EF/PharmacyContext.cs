using Microsoft.EntityFrameworkCore;
using Pharmacy.Core.Models;

namespace Pharmacy.Infrastructure.EF
{
    public class PharmacyContext : DbContext
    {
        private readonly SqlSettings _settings;
        public DbSet<User> Users { get; set; }

        public PharmacyContext(DbContextOptions<PharmacyContext> options, SqlSettings settings) : base(options)
        {
            _settings = settings;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (_settings.InMemory)
            {
                optionsBuilder.UseInMemoryDatabase(_settings.InMemoryDatabaseName);

                return;
            }
            optionsBuilder.UseSqlServer(_settings.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var itemBuilder = modelBuilder.Entity<User>();
            itemBuilder.HasKey(x => x.Id);
        }
    }
}