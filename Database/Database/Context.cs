using Database.Database.Model;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;


namespace Database.Database
{
    public class Context : DbContext
    {
        private Context() { }

        private static Context? instance;
        public static Context Instance
        {
            get
            {
                instance ??= new Context();
                return instance;
            }
        }

        public DbSet<Flight> Flights { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Airline> Airlines { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            SqlConnectionStringBuilder builder1 = new SqlConnectionStringBuilder();
            builder1.DataSource = "localhost, 1433";
            builder1.InitialCatalog = "Airlines2";
            builder1.Authentication = SqlAuthenticationMethod.SqlPassword;
            builder1.UserID = "sa";
            builder1.Password = "Database123456!";

            optionsBuilder.EnableSensitiveDataLogging();

            optionsBuilder.UseSqlServer(builder1.ConnectionString);

            optionsBuilder.UseSqlServer();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Flight>().HasOne(x => x.From).WithMany();
            modelBuilder.Entity<Flight>().HasOne(x => x.Destination).WithMany();

            modelBuilder.Entity<Flight>().HasOne(x => x.Airline).WithMany();

            Seed(modelBuilder);
        }


        private void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>().HasData(
                new City
                {
                    Id = 1,
                    Name = "Luxembourg",
                    Population = 100000
                }
            );
            modelBuilder.Entity<Airline>().HasData(
                new Airline { Id = 1, Name = "WizzAir" },
                new Airline { Id = 2, Name = "RyanAir" }
            );

            modelBuilder.Entity<Flight>().HasData(
                new Flight
                {
                    Id = 1,
                    AirlineId = 1,
                    FromId = 1,
                    DestinationId = 1,
                    Distance = 100,
                    FlightDuration = 10,
                    KmPrice = 2
                }
            );
        }
    }
}
