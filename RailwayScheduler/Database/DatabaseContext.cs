using Microsoft.EntityFrameworkCore;
using RailwayScheduler.Models;

namespace RailwayScheduler.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<Train> Trains { get; set; }
    }
}
