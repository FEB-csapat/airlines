using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlinesPc.DataReaders
{
    public class CityPopulation
    {
        public string CityName { get; private set; }
        public int CityPopulationCount { get; private set; }
        public CityPopulation(string row)
        {
            string[] helper = row.Split(';');
            CityName = helper[0];
            CityPopulationCount = int.Parse(helper[1]);
        }

    }
}
