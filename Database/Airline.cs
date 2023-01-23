﻿using Newtonsoft.Json;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;
using System.Xml.Linq;

namespace Database
{
    public class Airline : JsonConverter
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public virtual ICollection<Flight> Flights { get; set; }

        [JsonConstructor]
        public Airline(string name, ICollection<Flight> flights)
        {
            this.Name = name;
            this.Flights = flights;
        }


        public Airline()
        {
            
        }

        public void Modify(Airline airline)
        {
            this.Name = airline.Name;
            this.Flights = airline.Flights;
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

  