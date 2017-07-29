using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Windows.Data.Json;
using WeatherApp.JsonUtils;

namespace WeatherApp.Network
{
    class IDManager
    {
        private string[] citiesList = { "\\cityA.list.json", "\\cityB.list.json", "\\cityC.list.json", "\\cityD.list.json",
                                                     "\\cityE.list.json",  "\\cityF.list.json",  "\\cityG.list.json",  "\\cityH.list.json", "\\cityI.list.json"};
        private const string ROOT = "Storage\\CityList";
        private static IDManager instance;

        private IDManager()
        {

        }

        public static IDManager GetInstance()
        {
            if(instance == null)
            {
                instance = new IDManager();
            }
            return instance;
        }




        public async Task<int> GetCityByName(string city_name)
        {
            
            Windows.Storage.StorageFolder appInstalledFolder = null;
            Windows.Storage.StorageFolder root = null;
            Windows.Storage.IStorageFile file = null;
            int i = 0;
            int id = 0;
            try
            {
                appInstalledFolder = Windows.ApplicationModel.Package.Current.InstalledLocation;
                root = await appInstalledFolder.GetFolderAsync(ROOT);

                while (id == 0 && i < citiesList.Length)
                {
                    file = await Windows.Storage.StorageFile.GetFileFromPathAsync(root.Path + citiesList[i]);
                    JsonObject jsonObj = JsonObject.Parse(await Windows.Storage.FileIO.ReadTextAsync(file));
                    JsonArray jsonArray = jsonObj.GetNamedArray("cities");
                    id = await FindCity(city_name, jsonArray);
                    i++;

                }
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.Write("Exception : " + ex.ToString() + "\n" );
            }

            return id;
        }

        private async Task<int> FindCity(string city_name, JsonArray jsonArray)
        {
            int id = 0;
            await Task.Run(() =>
            {


                foreach (var data in jsonArray)
                {
                    JsonObject item = data.GetObject();
                    if (item.GetNamedString("name").Equals(city_name))
                    {
                        id = (int)item.GetNamedNumber("id");
                        break;
                    }
                }
            }
            );
            return id;
        }
    }
}
