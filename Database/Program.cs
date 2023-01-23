// See https://aka.ms/new-console-template for more information
using Database;
using Database.Model;

Console.WriteLine("Hello, World!");


Flight flight = new Database.Flight();


Context.Instance.Flights.Add(flight);

Context.Instance.SaveChanges();



Console.WriteLine("Flights: " + Context.Instance.Flights.ToList().Count);




