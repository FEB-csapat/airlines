using Database.Database.Model.ViewModel;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Database.Model
{
    public class Flight
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

        public int Distance { get; set; }

        public int FlightDuration { get; set; }
        public int KmPrice { get; set; }


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

        public void Modify(FlightInputViewModel flight)
        {
            FromId = flight.FromId;
            DestinationId = flight.DestinationId;
            AirlineId = flight.AirlineId;
            Distance = flight.Distance;
            KmPrice = flight.KmPrice;
            FlightDuration = flight.FlightDuration;
        }


        public FlightOutputViewModel createOutputModel()
        {
            return new FlightOutputViewModel(Id, Airline, From, Destination, Distance, FlightDuration, KmPrice);
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static Flight? FromJson(string json)
        {
            return JsonConvert.DeserializeObject<Flight>(json);
        }
    }
}
