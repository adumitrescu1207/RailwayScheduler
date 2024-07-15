using Microsoft.EntityFrameworkCore;
using RailwayScheduler.Models;

namespace RailwayScheduler.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<Train> Trains { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed initial data with integer values for TimeSource and TimeDestination
            modelBuilder.Entity<Train>().HasData(
                new Train { Id = 1, Source = "Station A", Destination = "Station B", TimeSource = 800, TimeDestination = 1000 },
                new Train { Id = 2, Source = "Station C", Destination = "Station D", TimeSource = 900, TimeDestination = 1100 }
            );
        }
    }
}
