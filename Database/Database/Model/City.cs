using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Database.Model
{
    public class City
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }
        public int Population { get; set; }

        [JsonConstructor]
        public City(string name, int population)
        {
            Name = name;
            Population = population;
        }

        public City()
        {

        }

        public void Modify(City city)
        {
            Name = city.Name;
            Population = city.Population;
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static City? FromJson(string json)
        {
            return JsonConvert.DeserializeObject<City>(json);
        }
    }
}

