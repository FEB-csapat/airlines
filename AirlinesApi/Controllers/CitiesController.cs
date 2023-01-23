using Database;
using Database.Model;
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
            List<City> list = Context.Instance.Cities.Where(x => x.Id == id).ToList();
            if (list.Count == 0)
            {
                return null;
            }
            else
            {
                return list[0].ToJson() ?? "null";
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
                Context context = new Context();
                /*
                 Context.Instance.Cities.Add(city);
                Context.Instance.SaveChanges();
                 */
                context.Cities.Add(city);
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Something went wrong");
            }

        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] City change)
        {
            List<City> list = Context.Instance.Cities.Where(x => x.Id == id).ToList();
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
            foreach (City city in Context.Instance.Cities)
            {
                if (city.Id == id)
                {

                    Context.Instance.Cities.Remove(city);
                    return;
                }
            }
        }
    }
}
