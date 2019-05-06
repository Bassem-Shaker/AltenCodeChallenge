using Microsoft.EntityFrameworkCore;
using CodeChallenge.VehiclesCore.Models.Entities;
using CodeChallenge.VehiclesCore.Utilities;

namespace CodeChallenge.VehiclesCore.EntityFramework
{
    public class VehiclesDatabaseContext : DbContext
    {
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehiclePingLog> VehiclePingLogs { get; set; }


        public VehiclesDatabaseContext(DbContextOptions<VehiclesDatabaseContext> options) : base(options)
        {

        }

        private string _connectionString;

        /// <summary>
        /// On Configuring
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Console.WriteLine("Connecting to Database = " + _connectionString);
            if (string.IsNullOrWhiteSpace(_connectionString))
            {
                ConnectionStrings connectionStrings = ConfigurationUtility.GetConnectionStrings();
                string databaseConnectionString = connectionStrings.PrimaryDatabaseConnectionString;
                optionsBuilder.UseSqlServer(databaseConnectionString);
            }
            else
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }
        public VehiclesDatabaseContext()
        {
            
        }
    }
}
