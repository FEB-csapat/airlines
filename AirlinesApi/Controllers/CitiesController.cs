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

        // GET flights
        [HttpGet]
        public string Get()
        {
            return JsonSerializer.Serialize(Context.Instance.Cities.ToList());
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            City? result = Context.Instance.Cities.SingleOrDefault(x => x.Id == id);
            if (result != null)
            {
                return result.ToJson();
            }
            else
            {
                return "null";
            }
        }

        /*
         https://stackoverflow.com/questions/56825827/sqlexception-cannot-insert-explicit-value-for-identity-column-in-table-table-n

        public void AddNew(Entry entry)
        {
            entry.CreatedTimestamp = DateTime.Now.ToString();
            var account = _context.Accounts.Single(x => x.Id = entry.Account.Id);
            var category = _context.Categories.Single(x => x.Id = entry.Category.Id);
            entry.Account = account; 
            entry.Category = category;
            _context.Entries.Add(entry);
            _context.SaveChanges();
        }
         */

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] City city)
        {
            if (city != null)
            {
                /*
                 Context.Instance.Cities.Add(city);
                Context.Instance.SaveChanges();
                 */
                Context.Instance.Cities.Add(city);
                Context.Instance.SaveChanges();
            }
            else
            {
            }

        }

        // PUT api/<ValuesController>/5
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

        // DELETE api/<ValuesController>/5
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
