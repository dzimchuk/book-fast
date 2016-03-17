using Microsoft.Data.Entity;

namespace BookFast.Data.Models
{
    internal class BookFastContext : DbContext
    {
        public DbSet<Facility> Facilities { get; set; }
        public DbSet<Accommodation> Accommodations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Facility>()
                        .HasMany(facility => facility.Accommodations)
                        .WithOne(acc => acc.Facility);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\ProjectsV12;Initial Catalog=BookFast;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }
    }
}