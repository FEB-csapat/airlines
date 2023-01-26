using Database.Database;
using Database.Database.Model;
using Database.Database.Model.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            List<FlightOutputViewModel> flights = Context.Instance.Flights
                .Include(x => x.Airline)
                .Include(x => x.From)
                .Include(x => x.Destination)
                .Select(x => x.createOutputModel())
                .ToList();

            return JsonSerializer.Serialize(flights);
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            Flight? result = Context.Instance.Flights
                .Include(x => x.Airline)
                .Include(x => x.From)
                .Include(x => x.Destination)
                .SingleOrDefault(x => x.Id == id);

            if (result != null)
            {
                return result.createOutputModel().ToJson();
            }
            return "null";
        }

        [HttpPost]
        public void Post([FromBody] FlightInputViewModel flight)
        {
            if (flight != null)
            {
                Context.Instance.Flights.Add(flight.CreateDatabaseModel());
                Context.Instance.SaveChanges();
            }
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] FlightInputViewModel change)
        {
            Flight? result = Context.Instance.Flights
                .Include(x => x.Airline)
                .Include(x => x.From)
                .Include(x => x.Destination)
                .SingleOrDefault(x => x.Id == id);

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
