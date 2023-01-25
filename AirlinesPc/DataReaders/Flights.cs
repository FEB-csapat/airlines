using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlinesPc.DataReaders
{
    public class Flights
    {
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static Flights FromJson(string json)
        {
            return JsonConvert.DeserializeObject<Flights>(json);
        }
        public string AirlineName { get; private set; }
        public string StartCity { get; private set; }
        public string TargetCity { get; private set; }
        public int TravelDistance { get; private set; }
        public int TravelTime { get; private set; }
        public int KmPrice { get; private set; }
        public int TimeHour { get; private set; }
        public int TimeMinute { get; private set; }
        public Flights(string row)
        {
            string[] helper = row.Split(';');
            AirlineName = helper[0];
            StartCity = helper[1];
            TargetCity = helper[2];
            TravelDistance = int.Parse(helper[3]);
            TravelTime = int.Parse(helper[4]);
            KmPrice = int.Parse(helper[5]);
            TimeHour = TravelTime / 60;
            TimeMinute = TravelTime % 60;
        }
    }
}
