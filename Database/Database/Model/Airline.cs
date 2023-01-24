using Database.Database.Model.ViewModel;
using Newtonsoft.Json;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;
using System.Xml.Linq;

namespace Database.Database.Model
{
    public class Airline : JsonConverter
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }

        [JsonConstructor]
        public Airline(string name)
        {
            Name = name;
        }

        public Airline()
        {

        }

        public void Modify(ViewModelAirline airline)
        {
            Name = airline.Name;
        }



        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static Airline? FromJson(string json)
        {
            return JsonConvert.DeserializeObject<Airline>(json);
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

