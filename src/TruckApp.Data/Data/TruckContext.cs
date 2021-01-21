using Microsoft.EntityFrameworkCore;
using TruckApp.Domain.Entities;

namespace TruckApp.Data.Data
{
    public class TruckContext : DbContext
    {
        public TruckContext(DbContextOptions<TruckContext> options): base(options)
        {
            
        }

        public DbSet<Truck> Trucks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TruckContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}