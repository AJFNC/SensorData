using Microsoft.EntityFrameworkCore;

namespace SensorData.Models
{
    public class SensorContext : DbContext
    {
        public SensorContext(DbContextOptions<SensorContext> options) : base(options) {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
        }

        public DbSet<Sensor>? Sensors { get; set; }
        public DbSet<Frequency>? Frequencies { get; set; }
        public DbSet<Spot> Spots { get; set; }

    }

}
