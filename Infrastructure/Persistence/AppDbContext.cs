using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<City> Cities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>()
                .HasMany(c => c.Regions)
                .WithOne(r => r.Country)
                .HasForeignKey(r => r.CountryId);

            modelBuilder.Entity<Region>()
                .HasMany(r => r.Cities)
                .WithOne(c => c.Region)
                .HasForeignKey(c => c.RegionId);
        }
    }
}
