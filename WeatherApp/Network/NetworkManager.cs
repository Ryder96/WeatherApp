using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Windows.Web.Http;
namespace WeatherApp.Network
{
    class NetworkManager
    {
        public Uri URI { set; get; }
        public HttpClient Client { set; get; }

        public NetworkManager()
        {
            Client = new HttpClient();
        }

        public async Task<string> InfoAbout(string cityName)
        {
            IDManager manager = IDManager.GetInstance();
            var id = await manager.GetCityByName(cityName);
            var response = await Client.GetStringAsync(BuildRequest.Build().ID_City(id).BuildUriByCityID());
            return response;
        }


    }
}
