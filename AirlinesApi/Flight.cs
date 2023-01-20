using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Formats.Asn1;
using Microsoft.EntityFrameworkCore.Migrations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirlinesApi
{
    public class Flight : JsonConverter
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; private set; }

        public string? AirlineName { get; set; }
        public City? From { get; set; }

        public City? Destination { get; set; }
        public int? Distance { get; set; }

        public int? FlightDuration { get; set; }
        public int? KmPrice { get; set; }

        private static int IdCounter = 0;

        public Flight(string line)
        {
            string[] l = line.Split(';');

            Id = ++IdCounter;
        }

        [JsonConstructor]
        public Flight(string airlineName, City from, City destination, int distance, int flightDuration, int kmPrice)
        {
            this.AirlineName = airlineName;
            this.From = from;
            this.Destination = destination;
            this.Distance = distance;
            this.FlightDuration = flightDuration;
            this.KmPrice = kmPrice;

            Id = ++IdCounter;
        }

        public Flight()
        {
            Id = ++IdCounter;
        }

        public void Modify(Flight flight)
        {
            this.AirlineName = flight.AirlineName;
            this.From = flight.From;
            this.Destination = flight.Destination;
            this.Distance = flight.Distance;
            this.FlightDuration = flight.FlightDuration;
            this.KmPrice = flight.KmPrice;
        }

        public void CopyAttributes(Flight otherSweets)
        {
            
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static Flight? FromJson(string json)
        {
            return JsonConvert.DeserializeObject<Flight>(json);
        }



        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }

        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            return serializer.Deserialize(reader, objectType);
        }

        public override bool CanConvert(Type objectType)
        {
            return true;
        }
    }
}
