using API_AppParkingSoft.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace API_AppParkingSoft.DAL
{
    //Contexto de la base de datos del proyecto
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Vehicle>().HasIndex(v => v.LicensePlate).IsUnique();
            //modelBuilder.Entity<Client>().HasIndex("clientName").IsUnique();
        }


        //DbSet tables
        public DbSet<CategoryVehicle> CategoryVehicles { get; set; }
        public DbSet<Rate> Rates { get; set; }
        public DbSet<Reserve> Reserves { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
    }
}
