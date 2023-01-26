using Database.Database;
using Database.Database.Model;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace AirlinesApi.Controllers
{

    [Route("cities/")]
    [ApiController]
    public class CitiesController : ControllerBase
    {

        [HttpGet]
        public string Get()
        {
            return JsonSerializer.Serialize(Context.Instance.Cities.ToList());
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            City? result = Context.Instance.Cities.SingleOrDefault(x => x.Id == id);
            if (result != null)
            {
                return result.ToJson();
            }
            return null;
        }

        [HttpPost]
        public void Post([FromBody] City city)
        {
            if (city != null)
            {
                Context.Instance.Cities.Add(city);
                Context.Instance.SaveChanges();
            }
            else
            {
            }

        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] City change)
        {
            City? result = Context.Instance.Cities.SingleOrDefault(x => x.Id == id);
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
            City? result = Context.Instance.Cities.SingleOrDefault(x => x.Id == id);

            if (result != null)
            {
                Context.Instance.Cities.Remove(result);
                Context.Instance.SaveChanges();
            }
        }
    }
}
