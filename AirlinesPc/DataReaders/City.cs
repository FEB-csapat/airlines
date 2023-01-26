using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Windows.Automation.Peers;

namespace AirlinesPc.DataReaders
{
    public class City
    {
        public string Name { get; private set; }
        public int Population { get; private set; }

        [JsonConstructor]
        public City(string name, int population)
        {
            Name = name;
            Population = population;
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
