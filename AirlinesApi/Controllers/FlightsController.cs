using AirlinesApi.Database.Model;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace AirlinesApi.Controllers
{

    [Route("flights/")]
    [ApiController]
    public class FlightsController : ControllerBase
    {

        // GET flights/5
        [HttpGet]

        public string Get()
        {
            return JsonSerializer.Serialize(Context.Instance.Flights.ToList());
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            List<Flight> list = Context.Instance.Flights.Where(x => x.Id == id).ToList();
            if (list.Count == 0)
            {
                return null;
            }
            else
            {
                return list[0].ToJson() ?? "null";
            }
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] Flight flight)
        {
            if (flight != null)
            {
                Context.Instance.Flights.Add(flight);
                Context.Instance.SaveChanges();
            }
            else
            {
                Console.WriteLine("Something went wrong");
            }

        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Flight change)
        {
            List<Flight> list = Context.Instance.Flights.Where(x => x.Id == id).ToList();
            if (list.Count == 0)
            {

            }
            else
            {
                list[0].Modify(change);
            }
        }


        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            foreach (Flight flight in Context.Instance.Flights)
            {
                if (flight.Id == id)
                {

                    Context.Instance.Flights.Remove(flight);
                    return;
                }
            }
        }
    }
}
