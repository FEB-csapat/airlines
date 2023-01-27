using Database.Database;
using Database.Database.Model;

Console.WriteLine("Hello, World!");


Flight flight = new Flight();


Context.Instance.Flights.Add(flight);

Context.Instance.SaveChanges();

Console.WriteLine("Flights: " + Context.Instance.Flights.ToList().Count);




