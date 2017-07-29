using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.JsonUtils
{
    class Coord
    {
        public double Lon { set; get; }
        public double Lat { set; get; }


        public override string ToString()
        {
            return "lon: " + Lon + "\nlat: " + Lat; 
        }
    }
}
