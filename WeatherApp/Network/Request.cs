using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WeatherApp.Network
{
    class Request
    {
        private const string end_point = "http://api.openweathermap.org/data/2.5/weather?";
        private const string API_KEY = "appid=cf94aeb6c914a65bceef6895aced6134";
        private string city;
        private int id_city;
        private Uri  uri;

        public Request() { }

        public Request City(string name)
        {
            city = name;
            return this;
        }

        public Request ID_City(int id)
        {
            id_city = id;
            return this;
        }

        public Uri BuildUriByCityID()
        {
            uri = BuildUri(end_point, id_city, API_KEY);
            return uri;
        }


        private Uri BuildUri(string endPoint, int id_city, string apiKey)
        {
            string url = endPoint + "id=" + id_city + "&" + apiKey;
            return new Uri(url);
        }

        public override string ToString()
        {
            return uri.ToString();
        }
    }
}
