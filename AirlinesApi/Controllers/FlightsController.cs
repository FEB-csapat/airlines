using Database.Database;
using Database.Database.Model;
using Database.Database.Model.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace AirlinesApi.Controllers
{
    [Route("flights/")]
    [ApiController]
    public class FlightsController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return JsonSerializer.Serialize(Context.Instance.Flights.ToList());
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            Flight? result = Context.Instance.Flights.SingleOrDefault(x => x.Id == id);

            if (result != null)
            {
                return result.ToJson();
            }
            return "null";
        }

        [HttpPost]
        public void Post([FromBody] FlightViewModel flight)
        {
            if (flight != null)
            {
                Flight real = new Flight();

                real.From = Context.Instance.Cities.SingleOrDefault(x => x.Id == flight.FromId);
                real.Destination = Context.Instance.Cities.SingleOrDefault(x => x.Id == flight.DestinationId);
                real.Airline = Context.Instance.Airlines.SingleOrDefault(x => x.Id == flight.AirlineId);
                real.Distance = flight.Distance;
                real.KmPrice = flight.KmPrice;
                real.FlightDuration = flight.FlightDuration;

                Context.Instance.Flights.Add(real);
                Context.Instance.SaveChanges();
            }
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] FlightViewModel change)
        {
            Flight? result = Context.Instance.Flights.SingleOrDefault(x => x.Id == id);

            if (result != null)
            {
                result.Modify(change);
                Context.Instance.Update(result);
                Context.Instance.SaveChanges();
            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Flight? result = Context.Instance.Flights.SingleOrDefault(x => x.Id == id);

            if (result != null)
            {
                Context.Instance.Flights.Remove(result);
                Context.Instance.SaveChanges();
            }
        }
    }
}
