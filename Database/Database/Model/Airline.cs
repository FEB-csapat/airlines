using Database.Database.Model.ViewModel;
using Newtonsoft.Json;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;
using System.Xml.Linq;

namespace Database.Database.Model
{
    public class Airline
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

        public void Modify(Airline airline)
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
    }
}

