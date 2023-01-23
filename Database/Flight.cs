using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database
{
    public class Flight : JsonConverter
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; private set; }

        [ForeignKey("AirlineId")]
        public virtual Airline? Airline { get; set; }

        [JsonIgnore]
        public int? AirlineId { get; set; }

        [ForeignKey("FromId")]
        public virtual City? From { get; set; }
        [JsonIgnore]
        public int? FromId { get; set; }

        [ForeignKey("DestinationId")]
        
        public virtual City? Destination { get; set; }
        [JsonIgnore]
        public int? DestinationId { get; set; }

        public int? Distance { get; set; }

        public int? FlightDuration { get; set; }
        public int? KmPrice { get; set; }

        public Flight(string line)
        {
            string[] l = line.Split(';');
        }

        [JsonConstructor]
        public Flight(Airline airline, City from, City destination, int distance, int flightDuration, int kmPrice)
        {
            this.Airline = airline;
            this.From = from;
            this.Destination = destination;
            this.Distance = distance;
            this.FlightDuration = flightDuration;
            this.KmPrice = kmPrice;
        }

        /*
        public static Flight FromPojo (PostPojoFlight postPojoFlight)
        {
            
        }
        */
        


        public Flight()
        {
            
        }
        

        public void Modify(Flight flight)
        {
            this.Airline = flight.Airline;
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
