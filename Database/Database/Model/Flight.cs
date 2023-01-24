using Database.Database.Model.ViewModel;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Database.Model
{
    public class Flight : JsonConverter
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("AirlineId")]
        public virtual Airline? Airline { get; set; }
        public int? AirlineId { get; set; }

        [ForeignKey("FromId")]
        public virtual City? From { get; set; }
        public int? FromId { get; set; }

        [ForeignKey("DestinationId")]
        public virtual City? Destination { get; set; }
        public int? DestinationId { get; set; }

        public int? Distance { get; set; }

        public int? FlightDuration { get; set; }
        public int? KmPrice { get; set; }


        [JsonConstructor]
        public Flight(Airline airline, City from, City destination, int distance, int flightDuration, int kmPrice)
        {
            Airline = airline;
            From = from;
            Destination = destination;
            Distance = distance;
            FlightDuration = flightDuration;
            KmPrice = kmPrice;
        }

        public Flight()
        {

        }

        public void Modify(FlightViewModel flight)
        {
            From = Context.Instance.Cities.SingleOrDefault(x => x.Id == flight.FromId);
            Destination = Context.Instance.Cities.SingleOrDefault(x => x.Id == flight.DestinationId);
            Airline = Context.Instance.Airlines.SingleOrDefault(x => x.Id == flight.AirlineId);
            Distance = flight.Distance;
            KmPrice = flight.KmPrice;
            FlightDuration = flight.FlightDuration;
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
