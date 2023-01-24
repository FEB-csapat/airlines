using Database.Database.Model;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;


namespace Database.Database
{
    public class Context : DbContext
    {
        public Context() { }

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
                    Id = 11,
                    Name = "Havanna",
                    Population = 2141652
                },
                new City
                {
                    Id = 12,
                    Name = "Libreville",
                    Population = 797003
                },
                new City
                {
                    Id = 13,
                    Name = "Luxembourg",
                    Population = 132780
                },
                new City
                {
                    Id = 14,
                    Name = "Madrid",
                    Population = 3280782
                },
                new City
                {
                    Id = 15,
                    Name = "Manila",
                    Population = 1846513
                },
                new City
                {
                    Id = 16,
                    Name = "Mexikóváros",
                    Population = 8851080
                },
                new City
                {
                    Id = 17,
                    Name = "Moszkva",
                    Population = 12455682
                },
                new City
                {
                    Id = 18,
                    Name = "Peking",
                    Population = 21893095
                },
                new City
                {
                    Id = 19,
                    Name = "Pozsony",
                    Population = 475503
                },
                new City
                {
                    Id = 20,
                    Name = "Prága",
                    Population = 1275406
                }
            );
            modelBuilder.Entity<Airline>().HasData(
                new Airline { Id = 1, Name = "WizzAir" },
                new Airline { Id = 2, Name = "RyanAir" },
                new Airline { Id = 3, Name = "British Airways" },
                new Airline { Id = 4, Name = "Air Serbia" },
                new Airline { Id = 5, Name = "SCAT Airlines" },
                new Airline { Id = 6, Name = "Belavia" },
                new Airline { Id = 7, Name = "Wingo" },
                new Airline { Id = 8, Name = "Iberia" },
                new Airline { Id = 9, Name = "Air France" },
                new Airline { Id = 10, Name = "Philippine Airlines" },
                new Airline { Id = 11, Name = "Luxair" },
                new Airline { Id = 12, Name = "Air China" },
                new Airline { Id = 13, Name = "AVIANCA" },
                new Airline { Id = 14, Name = "Aero4M" },
                new Airline { Id = 15, Name = "Aeromexico" }
            );

            modelBuilder.Entity<Flight>().HasData(
                new Flight
                {
                    Id = 1,
                    AirlineId = 1,
                    FromId = 1,
                    DestinationId = 2,
                    Distance = 1450,
                    FlightDuration = 145,
                    KmPrice = 6
                },
                new Flight
                {
                    Id = 2,
                    AirlineId = 3,
                    FromId = 1,
                    DestinationId = 2,
                    Distance = 1450,
                    FlightDuration = 155,
                    KmPrice = 7
                },
                new Flight
                {
                    Id = 3,
                    AirlineId = 4,
                    FromId = 1,
                    DestinationId = 8,
                    Distance = 318,
                    FlightDuration = 54,
                    KmPrice = 5
                },
                new Flight
                {
                    Id = 4,
                    AirlineId = 4,
                    FromId = 8,
                    DestinationId = 3,
                    Distance = 198,
                    FlightDuration = 45,
                    KmPrice = 5
                },
                new Flight
                {
                    Id = 5,
                    AirlineId = 3,
                    FromId = 2,
                    DestinationId = 14,
                    Distance = 1252,
                    FlightDuration = 155,
                    KmPrice = 7
                },
                new Flight
                {
                    Id = 6,
                    AirlineId = 3,
                    FromId = 14,
                    DestinationId = 2,
                    Distance = 1252,
                    FlightDuration = 155,
                    KmPrice = 7
                },
                new Flight
                {
                    Id = 7,
                    AirlineId = 5,
                    FromId = 6,
                    DestinationId = 17,
                    Distance = 2304,
                    FlightDuration = 235,
                    KmPrice = 5
                },
                new Flight
                {
                    Id = 8,
                    AirlineId = 5,
                    FromId = 17,
                    DestinationId = 6,
                    Distance = 2304,
                    FlightDuration = 235,
                    KmPrice = 5
                },
                new Flight
                {
                    Id = 9,
                    AirlineId = 6,
                    FromId = 6,
                    DestinationId = 5,
                    Distance = 2961,
                    FlightDuration = 240,
                    KmPrice = 8
                },
                new Flight
                {
                    Id = 10,
                    AirlineId = 6,
                    FromId = 5,
                    DestinationId = 6,
                    Distance = 2961,
                    FlightDuration = 240,
                    KmPrice = 8
                },
                new Flight
                {
                    Id = 11,
                    AirlineId = 7,
                    FromId = 9,
                    DestinationId = 11,
                    Distance = 2230,
                    FlightDuration = 273,
                    KmPrice = 4
                },
                new Flight
                {
                    Id = 12,
                    AirlineId = 7,
                    FromId = 11,
                    DestinationId = 9,
                    Distance = 2230,
                    FlightDuration = 260,
                    KmPrice = 4
                },
                new Flight
                {
                    Id = 13,
                    AirlineId = 8,
                    FromId = 10,
                    DestinationId = 14,
                    Distance = 3170,
                    FlightDuration = 265,
                    KmPrice = 8
                },
                new Flight
                {
                    Id = 14,
                    AirlineId = 8,
                    FromId = 14,
                    DestinationId = 10,
                    Distance = 3170,
                    FlightDuration = 345,
                    KmPrice = 8
                },
                new Flight
                {
                    Id = 15,
                    AirlineId = 9,
                    FromId = 7,
                    DestinationId = 12,
                    Distance = 5467,
                    FlightDuration = 425,
                    KmPrice = 6
                },
                new Flight
                {
                    Id = 16,
                    AirlineId = 15,
                    FromId = 11,
                    DestinationId = 16,
                    Distance = 1780,
                    FlightDuration = 245,
                    KmPrice = 5
                },
                new Flight
                {
                    Id = 17,
                    AirlineId = 2,
                    FromId = 20,
                    DestinationId = 1,
                    Distance = 471,
                    FlightDuration = 70,
                    KmPrice = 5
                },
                new Flight
                {
                    Id = 18,
                    AirlineId = 2,
                    FromId = 1,
                    DestinationId = 20,
                    Distance = 471,
                    FlightDuration = 75,
                    KmPrice = 5
                },
                new Flight
                {
                    Id = 19,
                    AirlineId = 6,
                    FromId = 17,
                    DestinationId = 5,
                    Distance = 689,
                    FlightDuration = 85,
                    KmPrice = 7
                },
                new Flight
                {
                    Id = 20,
                    AirlineId = 15,
                    FromId = 4,
                    DestinationId = 16,
                    Distance = 7472,
                    FlightDuration = 655,
                    KmPrice = 8
                },
                new Flight
                {
                    Id = 21,
                    AirlineId = 15,
                    FromId = 16,
                    DestinationId = 4,
                    Distance = 7472,
                    FlightDuration = 595,
                    KmPrice = 7
                },
                new Flight
                {
                    Id = 22,
                    AirlineId = 10,
                    FromId = 15,
                    DestinationId = 18,
                    Distance = 2890,
                    FlightDuration = 305,
                    KmPrice = 6
                },
                new Flight
                {
                    Id = 23,
                    AirlineId = 1,
                    FromId = 3,
                    DestinationId = 2,
                    Distance = 1657,
                    FlightDuration = 180,
                    KmPrice = 5
                },
                new Flight
                {
                    Id = 24,
                    AirlineId = 1,
                    FromId = 2,
                    DestinationId = 3,
                    Distance = 1657,
                    FlightDuration = 155,
                    KmPrice = 5
                },
                new Flight
                {
                    Id = 25,
                    AirlineId = 11,
                    FromId = 10,
                    DestinationId = 13,
                    Distance = 4446,
                    FlightDuration = 425,
                    KmPrice = 10
                },
                new Flight
                {
                    Id = 26,
                    AirlineId = 9,
                    FromId = 1,
                    DestinationId = 7,
                    Distance = 1252,
                    FlightDuration = 145,
                    KmPrice = 8
                },
                new Flight
                {
                    Id = 27,
                    AirlineId = 9,
                    FromId = 7,
                    DestinationId = 1,
                    Distance = 1252,
                    FlightDuration = 135,
                    KmPrice = 8
                },
                new Flight
                {
                    Id = 28,
                    AirlineId = 1,
                    FromId = 1,
                    DestinationId = 6,
                    Distance = 3754,
                    FlightDuration = 305,
                    KmPrice = 6
                },
                new Flight
                {
                    Id = 29,
                    AirlineId = 1,
                    FromId = 6,
                    DestinationId = 1,
                    Distance = 3754,
                    FlightDuration = 380,
                    KmPrice = 6
                },
                new Flight
                {
                    Id = 30,
                    AirlineId = 11,
                    FromId = 1,
                    DestinationId = 13,
                    Distance = 993,
                    FlightDuration = 130,
                    KmPrice = 5
                },
                new Flight
                {
                    Id = 31,
                    AirlineId = 11,
                    FromId = 13,
                    DestinationId = 1,
                    Distance = 993,
                    FlightDuration = 130,
                    KmPrice = 5
                },
                new Flight
                {
                    Id = 32,
                    AirlineId = 2,
                    FromId = 1,
                    DestinationId = 14,
                    Distance = 1982,
                    FlightDuration = 210,
                    KmPrice = 6
                },
                new Flight
                {
                    Id = 33,
                    AirlineId = 2,
                    FromId = 14,
                    DestinationId = 1,
                    Distance = 1982,
                    FlightDuration = 210,
                    KmPrice = 6
                },
                new Flight
                {
                    Id = 34,
                    AirlineId = 12,
                    FromId = 18,
                    DestinationId = 1,
                    Distance = 7371,
                    FlightDuration = 625,
                    KmPrice = 9
                },
                new Flight
                {
                    Id = 35,
                    AirlineId = 12,
                    FromId = 18,
                    DestinationId = 2,
                    Distance = 8196,
                    FlightDuration = 660,
                    KmPrice = 10
                },
                new Flight
                {
                    Id = 36,
                    AirlineId = 12,
                    FromId = 2,
                    DestinationId = 18,
                    Distance = 8196,
                    FlightDuration = 660,
                    KmPrice = 10
                },
                new Flight
                {
                    Id = 37,
                    AirlineId = 12,
                    FromId = 18,
                    DestinationId = 5,
                    Distance = 6502,
                    FlightDuration = 555,
                    KmPrice = 9
                },
                new Flight
                {
                    Id = 38,
                    AirlineId = 12,
                    FromId = 18,
                    DestinationId = 7,
                    Distance = 8233,
                    FlightDuration = 670,
                    KmPrice = 11
                },
                new Flight
                {
                    Id = 39,
                    AirlineId = 12,
                    FromId = 7,
                    DestinationId = 18,
                    Distance = 8233,
                    FlightDuration = 670,
                    KmPrice = 11
                },
                new Flight
                {
                    Id = 40,
                    AirlineId = 12,
                    FromId = 18,
                    DestinationId = 14,
                    Distance = 9255,
                    FlightDuration = 705,
                    KmPrice = 12
                },
                new Flight
                {
                    Id = 41,
                    AirlineId = 13,
                    FromId = 2,
                    DestinationId = 9,
                    Distance = 8518,
                    FlightDuration = 675,
                    KmPrice = 11
                },
                new Flight
                {
                    Id = 42,
                    AirlineId = 13,
                    FromId = 9,
                    DestinationId = 2,
                    Distance = 8518,
                    FlightDuration = 625,
                    KmPrice = 11
                },
                new Flight
                {
                    Id = 43,
                    AirlineId = 9,
                    FromId = 2,
                    DestinationId = 7,
                    Distance = 348,
                    FlightDuration = 85,
                    KmPrice = 10
                },
                new Flight
                {
                    Id = 44,
                    AirlineId = 9,
                    FromId = 7,
                    DestinationId = 2,
                    Distance = 348,
                    FlightDuration = 85,
                    KmPrice = 10
                },
                new Flight
                {
                    Id = 45,
                    AirlineId = 3,
                    FromId = 2,
                    DestinationId = 19,
                    Distance = 1556,
                    FlightDuration = 180,
                    KmPrice = 9
                },
                new Flight
                {
                    Id = 46,
                    AirlineId = 3,
                    FromId = 19,
                    DestinationId = 2,
                    Distance = 1556,
                    FlightDuration = 180,
                    KmPrice = 10
                },
                new Flight
                {
                    Id = 47,
                    AirlineId = 12,
                    FromId = 18,
                    DestinationId = 19,
                    Distance = 7845,
                    FlightDuration = 645,
                    KmPrice =9
                },
                new Flight
                {
                    Id = 48,
                    AirlineId = 12,
                    FromId = 19,
                    DestinationId = 18,
                    Distance = 7845,
                    FlightDuration = 635,
                    KmPrice = 9
                },
                new Flight
                {
                    Id = 49,
                    AirlineId = 14,
                    FromId = 19,
                    DestinationId = 9,
                    Distance = 9713,
                    FlightDuration = 715,
                    KmPrice =11
                },
                new Flight
                {
                    Id = 50,
                    AirlineId = 14,
                    FromId = 9,
                    DestinationId = 19,
                    Distance = 9713,
                    FlightDuration = 715,
                    KmPrice = 11
                },
                new Flight
                {
                    Id = 51,
                    AirlineId = 1,
                    FromId = 3,
                    DestinationId = 12,
                    Distance = 4910,
                    FlightDuration = 540,
                    KmPrice = 12
                },
                new Flight
                {
                    Id = 52,
                    AirlineId = 1,
                    FromId = 12,
                    DestinationId = 3,
                    Distance = 4910,
                    FlightDuration = 510,
                    KmPrice =12
                },
                new Flight
                {
                    Id = 53,
                    AirlineId = 15,
                    FromId = 9,
                    DestinationId = 16,
                    Distance = 3169,
                    FlightDuration = 340,
                    KmPrice = 10
                },
                new Flight
                {
                    Id = 54,
                    AirlineId = 15,
                    FromId = 16,
                    DestinationId = 9,
                    Distance = 3169,
                    FlightDuration = 360,
                    KmPrice = 10
                },
                new Flight
                {
                    Id = 55,
                    AirlineId = 2,
                    FromId = 20,
                    DestinationId = 10,
                    Distance = 4860,
                    FlightDuration = 415,
                    KmPrice = 15
                },
                new Flight
                {
                    Id = 56,
                    AirlineId = 2,
                    FromId = 10,
                    DestinationId = 20,
                    Distance = 4860,
                    FlightDuration = 425,
                    KmPrice = 15
                },
                new Flight
                {
                    Id = 57,
                    AirlineId = 10,
                    FromId = 15,
                    DestinationId = 4,
                    Distance = 4996,
                    FlightDuration = 390,
                    KmPrice = 6
                },
                new Flight
                {
                    Id = 58,
                    AirlineId = 10,
                    FromId = 4,
                    DestinationId = 15,
                    Distance = 4996,
                    FlightDuration = 390,
                    KmPrice = 6
                },
                new Flight
                {
                    Id = 59,
                    AirlineId = 2,
                    FromId = 8,
                    DestinationId = 20,
                    Distance = 742,
                    FlightDuration = 200,
                    KmPrice =10
                },
                new Flight
                {
                    Id = 60,
                    AirlineId = 2,
                    FromId = 20,
                    DestinationId = 8,
                    Distance = 742,
                    FlightDuration = 200,
                    KmPrice =10
                }
            );
        }
    }
}
