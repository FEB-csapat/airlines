// See https://aka.ms/new-console-template for more information
using Database;
using Database.Model;

Console.WriteLine("Hello, World!");

Context context = new Context();

Flight flight = new Database.Flight();

flight.Airline22 = "vizair";

context.Flights.Add(flight);

context.SaveChanges();



Console.WriteLine("Flights: " + context.Flights.ToList().Count);




