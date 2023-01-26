using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlinesPc.DataReaders
{
    public class City
    {
        public string Name { get; private set; }
        public int Population { get; private set; }
        public City(string row)
        {
            string[] helper = row.Split(';');
            Name = helper[0];
            Population = int.Parse(helper[1]);
        }

    }
}
