using Database.Database.Model;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;


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
                    Name = "Budapest",
                    Population = 1800000
                },
                new City
                {
                    Id = 2,
                    Name = "London",
                    Population = 8800000
                },
                new City
                {
                    Id = 3,
                    Name = "Szarajevó",
                    Population = 3500000
                },
                new City
                {
                    Id = 4,
                    Name = "Sao Paulo",
                    Population = 12325232
                },
                new City
                {
                    Id = 5,
                    Name = "Minszk",
                    Population = 9400000
                },
                new City
                {
                    Id = 6,
                    Name = "Asztana",
                    Population = 16700000
                },
                new City
                {
                    Id = 7,
                    Name = "Párizs",
                    Population = 2165423
                },
                new City
                {
                    Id = 8,
                    Name = "Belgrád",
                    Population = 1378682
                },
                new City
                {
                    Id = 9,
                    Name = "Bogotá",
                    Population = 7743955
                },
                new City
                {
                    Id = 10,
                    Name = "Dakar",
                    Population = 1438725
                },
                new City
                {
                    Id = 10,
                    Name = "Havanna",
                    Population = 2141652
                },
                new City
                {
                    Id = 10,
                    Name = "Libreville",
                    Population = 797003
                },
                new City
                {
                    Id = 10,
                    Name = "Luxembourg",
                    Population = 132780
                },
                new City
                {
                    Id = 10,
                    Name = "Madrid",
                    Population = 3280782
                },
                new City
                {
                    Id = 10,
                    Name = "Manila",
                    Population = 1846513
                },
                new City
                {
                    Id = 10,
                    Name = "Mexikóváros",
                    Population = 8851080
                },
                new City
                {
                    Id = 10,
                    Name = "Moszkva",
                    Population = 12455682
                },
                new City
                {
                    Id = 10,
                    Name = "Peking",
                    Population = 21893095
                },
                new City
                {
                    Id = 10,
                    Name = "Pozsony",
                    Population = 475503
                },
                new City
                {
                    Id = 10,
                    Name = "Prága",
                    Population = 1275406
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
