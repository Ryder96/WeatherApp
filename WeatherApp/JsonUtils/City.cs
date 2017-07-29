using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.JsonUtils
{
    class City
    {
        public int ID { set; get; }
        public string Name { set; get; }
        public string Country { set; get; }
        public Coord Coord { set; get; }

        public City()
        {
            Coord = new Coord();
        }

        public static City Build()
        {
            return new City();
        }

        public City NameOf(string name)
        {
            this.Name = name;
            return this;
        }

        public City IDOf(int id)
        {
            this.ID = id;
            return this;
        }

        public City CountryOf(string country)
        {
            this.Country = country;
            return this;
        }

        public City CoordOf(double lon, double lat)
        {
            Coord.Lon = lon;
            Coord.Lat = lat;
            return this;
        }

        public City CoordOf(Coord coord)
        {
            this.Coord = coord;
            return this;
        }


        public override string  ToString()
        {
            return "id: " + ID + "\nname: " + Name + "\ncoutry: we" + Country + "\ncoord: " + Coord;
        }
    }
}
