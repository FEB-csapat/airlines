using Database.Database.Model;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Database.Model.ViewModel
{
    public class FlightInputViewModel
    {
        public int AirlineId { get; set; }
        public int FromId { get; set; }
        public int DestinationId { get; set; }

        public int Distance { get; set; }
        public int FlightDuration { get; set; }
        public int KmPrice { get; set; }

        [JsonConstructor]
        public FlightInputViewModel(int airlineId, int fromId, int destinationId, int distance, int flightDuration, int kmPrice)
        {
            AirlineId = airlineId;
            FromId = fromId;
            DestinationId = destinationId;
            Distance = distance;
            FlightDuration = flightDuration;
            KmPrice = kmPrice;
        }

        
        public Flight CreateDatabaseModel()
        {
            Flight real = new Flight();

            real.FromId = FromId;
            real.DestinationId= DestinationId;
            real.AirlineId = AirlineId;
            real.Distance = Distance;
            real.KmPrice = KmPrice;
            real.FlightDuration = FlightDuration;

            return real;
        }
    }
}
