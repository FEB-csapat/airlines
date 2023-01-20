using AirlinesApi.Database.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Xml.Linq;

namespace AirlinesApi
{
    /*
    public class DataManager
    {
        private DataManager() { }
        private static DataManager? instance;
        public static DataManager Instance
        {
            get
            {
                instance ??= new DataManager();
                return instance;
            }
        }
        public Context context = new Context();

        public void Load()
        {
            Context context = new Context();
        }

        public void AddCity(Flight city)
        {
            context.Cities.Add(city);
            context.SaveChanges();
        }

        public List<Flight> GetCities()
        {
            return context.Cities.ToList();
        }

        public Flight? GetCityById(int id)
        {
            List<Flight> list = context.Cities.Where(x=>x.Id == id).ToList();
            if (list.Count == 0)
            {
                return null;
            }
            else
            {
                return list[0];
            }
        }

        public void AddFlight(Flight flight)
        {
            context.Flights.Add(flight);
            context.SaveChanges();
        }

        public List<Flight> GetFlights()
        {
            return context.Flights.ToList();
        }

        public Flight? GetFlightById(int id)
        {
            List<Flight> list = context.Flights.Where(x => x.Id == id).ToList();
            if (list.Count == 0)
            {
                return null;
            }
            else
            {
                return list[0];
            }
        }

        public void RemoveFlightById(int id)
        {

            foreach (Flight flight in context.Flights)
            {
                if (flight.Id == id)
                {
                    
                    context.Flights.Remove(flight);
                    return;
                }
            }
        }


        public void UpdateFlightById(int id, Flight change)
        {
            Flight? flight = GetFlightById(id);
            if (flight != null)
            {
                flight.Modify(change);
            }
            else
            {

            }
        }


        
        public Flight? GetSweetsById(int id)
        {
            return sweetss.Find(x => x.Id == id);
        }

        public void SetSweetsById(int id, Flight sweets)
        {
            Flight? oldSweets = sweetss.Find(x => x.Id == id);
            if (oldSweets != null)
            {
                oldSweets.CopyAttributes(sweets);
            }
        }


        public void AddSweets(Flight sweets)
        {
            sweetss.Add(sweets);
        }

        public void DeleteSweetsById(int id)
        {
            Flight? sweets = sweetss.Find(x => x.Id == id);
            if (sweets != null)
            {
                sweetss.Remove(sweets);
            }
        }
        

    }
    */


}
