using Database.Database;
using Database.Database.Model;
using Database.Database.Model.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Net;
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
        public string? Get(int id)
        {
            Airline? result = Context.Instance.Airlines.SingleOrDefault(x => x.Id == id);

            if (result != null)
            {
                return result.ToJson();
            }
            return null;
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] ViewModelAirline airline)
        {
            if (airline != null)
            {
                Airline airline2 = new Airline(airline.Name);

                Context.Instance.Airlines.Add(airline2);
                Context.Instance.SaveChanges();
            }
            else
            {
            }

        }


        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ViewModelAirline change)
        {

            Airline? result = Context.Instance.Airlines.SingleOrDefault(x => x.Id == id);
            if (result != null)
            {
                result.Modify(change);
                Context.Instance.Update(result);
                Context.Instance.SaveChanges();
            }
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Airline? result = Context.Instance.Airlines.SingleOrDefault(x => x.Id == id);

            if (result != null)
            {
                Context.Instance.Airlines.Remove(result);
                Context.Instance.SaveChanges();
            }
            

            // throw new System.Web.Http.HttpResponseException(HttpStatusCode.NotFound);
        }
    }
}
