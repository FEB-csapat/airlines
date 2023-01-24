using Database.Database.Model;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Database.Model.ViewModel
{
    public class FlightViewModel : JsonConverter
    {
        public int Id { get; set; }

        public int AirlineId { get; set; }

        public int FromId { get; set; }

        public int DestinationId { get; set; }


        public int? Distance { get; set; }

        public int? FlightDuration { get; set; }
        public int? KmPrice { get; set; }

        [JsonConstructor]
        public FlightViewModel(int Id, int airlineId, int fromId, int destinationId, int distance, int flightDuration, int kmPrice)
        {
            this.Id = Id;
            AirlineId = airlineId;
            FromId = fromId;
            DestinationId = destinationId;
            Distance = distance;
            FlightDuration = flightDuration;
            KmPrice = kmPrice;
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
