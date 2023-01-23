using Newtonsoft.Json;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;
using System.Xml.Linq;

namespace Database
{
    public class City : JsonConverter
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Population { get; set; }

        [JsonIgnore]
        public virtual ICollection<Flight> Flights { get; set; }

        [JsonConstructor]
        public City(string name, int population, ICollection<Flight> flights)
        {
            this.Name = name;
            this.Population = population;
            this.Flights = flights;

        }

        
        public City()
        {
            

        }
        


        public void Modify(City city)
        {
            this.Name = city.Name;
            this.Population = city.Population;
            this.Flights = city.Flights;
        }


        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static City? FromJson(string json)
        {
            return JsonConvert.DeserializeObject<City>(json);
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

  