using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Data.Json;
using WeatherApp.Network;
using System.Threading.Tasks;

namespace WeatherApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        public MainPage()
        {
            this.InitializeComponent();
            DisplayInformationAbout();
        }


        private async void DisplayInformationAbout()
        {
         
            Response.Text = await isRainig();
        }

        private async Task<string> isRainig()
        {
            NetworkManager netManager = new NetworkManager();
            JsonObject jsonObj = JsonObject.Parse(await netManager.InfoAbout("Impruneta"));
            JsonArray weather = jsonObj.GetNamedArray("weather");
            jsonObj = weather.GetObjectAt(0);
            if (jsonObj.GetNamedString("main").Equals("Rain"))
            {
                return "SI";
            }
            return "NO";
        }
    }
}
