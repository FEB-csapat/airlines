using AirlinesPc.DataReaders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Database.Database.Model.ViewModel;

namespace AirlinesPc
{
    public class RestAPIManager
    {

        HttpClient kliens = new HttpClient();
        public RestAPIManager(string base_url)
        {
            kliens.BaseAddress = new Uri(base_url);
            kliens.DefaultRequestHeaders.Accept.Clear();
            kliens.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public Flight GetAirline(int id)
        {
            Flight visszateres = null;
            HttpResponseMessage valasz = kliens.GetAsync("flights/" + id).Result;
            if (valasz.IsSuccessStatusCode)
            {
                string str = valasz.Content.ReadAsStringAsync().Result;
                visszateres = Flight.FromJson(str);
            }
            return visszateres;
        }
        public City GetCity(string path)
        {
            City visszateres = null;
            HttpResponseMessage valasz = kliens.GetAsync(path).Result;
            if (valasz.IsSuccessStatusCode)
            {
                string str = valasz.Content.ReadAsStringAsync().Result;
                visszateres = City.FromJson(str);
            }
            return visszateres;
        }
    }
}
