using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database
{
    public class FlightViewModel : JsonConverter
    {
        public int Id { get; private set; }

        public int? Distance { get; set; }

        public int? FlightDuration { get; set; }
        public int? KmPrice { get; set; }

        [JsonConstructor]
        public FlightViewModel(int distance, int flightDuration, int kmPrice)
        {
            this.Distance = distance;
            this.FlightDuration = flightDuration;
            this.KmPrice = kmPrice;
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
