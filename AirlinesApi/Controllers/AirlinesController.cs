using Database;
using Database.Model;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace AirlinesApi.Controllers
{
    
    [Route("airlines/")]
    [ApiController]
    public class AirlinesController : ControllerBase
    {

        // GET api/<ValuesController>/5
        [HttpGet]
        public string Get()
        {
            return JsonSerializer.Serialize(Context.Instance.Airlines.ToList());
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            List<Airline> list = Context.Instance.Airlines.Where(x => x.Id == id).ToList();
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
        public void Post([FromBody] Airline airline)
        {
            if (airline != null)
            {
                Context.Instance.Airlines.Add(airline);
                Context.Instance.SaveChanges();
            }
            else
            {
                Console.WriteLine("Something went wrong");
            }

        }


        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Airline change)
        {
            List<Airline> list = Context.Instance.Airlines.Where(x => x.Id == id).ToList();
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
            foreach (Airline airline in Context.Instance.Airlines)
            {
                if (airline.Id == id)
                {

                    Context.Instance.Airlines.Remove(airline);
                    return;
                }
            }
        }
    }
}
