using Database;
using Newtonsoft.Json;

namespace AirlinesApi
{
    public class PostPojoFlight : JsonConverter
    {

       // public int Id { get; private set; }

        public int? AirlineId { get; set; }

        public int? FromId { get; set; }

        public int? DestinationId { get; set; }

        public int? Distance { get; set; }

        public int? FlightDuration { get; set; }
        public int? KmPrice { get; set; }
    

        [JsonConstructor]
        public PostPojoFlight( int airlineId, int fromId, int destinationId, int distance, int flightDuration, int kmPrice)
        {
            this.AirlineId = airlineId;
            this.FromId = fromId;
            this.DestinationId = destinationId;
            this.Distance = distance;
            this.FlightDuration = flightDuration;
            this.KmPrice = kmPrice;

        }

        public PostPojoFlight()
        {

        }

        public Flight toDatabaseObject()
        {
            Flight flight =  new Flight();

            flight.AirlineId = this.AirlineId;
            flight.FromId = this.FromId;
            flight.DestinationId = this.DestinationId;
            flight.Distance = this.Distance;
            flight.KmPrice = this.KmPrice;
            flight.FlightDuration = this.FlightDuration;

            return flight;
        }



        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static PostPojoFlight? FromJson(string json)
        {
            return JsonConvert.DeserializeObject<PostPojoFlight>(json);
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
