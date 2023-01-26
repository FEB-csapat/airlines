using AirlinesPc.DataReaders;
using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json;

namespace Database.Database.Model.ViewModel
{
    public class Flight
    {
        public int Id { get; set; }
        public Airline Airline { get; set; }

        public City From { get; set; }

        public City Destination { get; set; }

        public int? Distance { get; set; }

        public int? FlightDuration { get; set; }
        public int? KmPrice { get; set; }
        [JsonConstructor]
        public Flight(int Id, Airline airline, City from, City destination, int distance, int flightDuration, int kmPrice)
        {
            this.Id = Id;
            Airline = airline;
            From = from;
            Destination = destination;
            Distance = distance;
            FlightDuration = flightDuration;
            KmPrice = kmPrice;
        }
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
        public static Flight? FromJson(string json)
        {
            return JsonConvert.DeserializeObject<Flight>(json);
        }
    }
}