using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;


namespace AirlinesApi.Database.Model
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


        // InvalidOperationException()


        // context.Flights.Include(x=> x.Cities) //

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            SqlConnectionStringBuilder builder1 = new SqlConnectionStringBuilder();
            builder1.DataSource = "localhost, 1433";
            builder1.InitialCatalog= "Airlines";
            builder1.Authentication= SqlAuthenticationMethod.SqlPassword;
            builder1.UserID = "sa";
            builder1.Password = "Database123456!";
            optionsBuilder.UseSqlServer(builder1.ConnectionString);

            optionsBuilder.UseSqlServer();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Flight>().HasOne(x => x.From).WithMany(x => x.Flights);

           // modelBuilder.Entity<City>().HasMany(x=> x.Flights).WithOne(x => x.From);
        }
    }
}
