using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace WeatherAPP
{
    class WeatherInfo
    {
        HttpClient client = new HttpClient();
        const string myAPI = "54f747b7fcfa4bd7a0142555230206";
        public void FindWaether()
        {
            string city = "Kiev";
            string apiUrl = $"https://api.weatherapi.com/v1/forecast.json?key={myAPI}&q={city}&days=1";
            HttpResponseMessage response = client.GetAsync(apiUrl).Result;
            string jsonResponse = response.Content.ReadAsStringAsync().Result;
            JsonDocument doc = JsonDocument.Parse(jsonResponse);
            float temp_c = doc.RootElement.GetProperty("current").GetProperty("temp_c").GetSingle();
            MessageBox.Show(temp_c.ToString());
        }
    }
}
