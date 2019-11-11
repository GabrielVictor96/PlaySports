using Microsoft.EntityFrameworkCore;
using PlaySports.Infra.Data.Mappings;

namespace PlaySports.Infra.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer(connectionString: "Data Source=den1.mssql7.gear.host;Initial Catalog=playsports;User ID=playsports;Password=Nd2Ph0s0-!RY");
        }
    }
}