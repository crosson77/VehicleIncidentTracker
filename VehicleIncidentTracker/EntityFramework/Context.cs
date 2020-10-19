using Microsoft.EntityFrameworkCore;

namespace VehicleIncidentTracker.EntityFramework
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
        : base(options)
        { }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Incident> Incidents { get; set; }
    }
}
