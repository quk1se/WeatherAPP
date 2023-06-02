using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows;
using System.Net.Http;
using System.Text.Json;
using System.Windows.Media.Effects;

namespace WeatherAPP
{
    internal class Style
    {
        private string weatherCondition;
        private int temperature;
        const string myAPI = "54f747b7fcfa4bd7a0142555230206";

        DateTime dt = DateTime.Now;
        HttpClient client = new HttpClient();
        public MainWindow parent;

        public string WeatherCondition
        {
            get { return weatherCondition; }
            set { weatherCondition = value; }
        }
        public int Temperature
        {
            get { return temperature; }
            set { temperature = value; }
        }

        public Style(MainWindow parent)
        {
            this.parent = parent;
        }
        public void ShowDate(TextBlock txt)
        {
            txt.Background = Brushes.Transparent;
            txt.Foreground = Brushes.White;
            txt.FontSize = 52;
            txt.FontFamily = new FontFamily("Arial Black");
            txt.FontStyle = FontStyles.Normal;
            txt.Text = dt.DayOfWeek.ToString().ToUpper();
        }
        public void ShowTemperatureInfo(TextBlock txt)
        {
            txt.Text = Temperature.ToString() + "\u00B0C";
            txt.Background = Brushes.Transparent;
            txt.Foreground = Brushes.White;
            txt.FontSize = 52;
            txt.FontFamily = new FontFamily("Arial Black");
            txt.FontStyle = FontStyles.Normal;
        }
        public void ShowWeatherConditionInfo(TextBlock txt)
        {
            txt.Text = WeatherCondition;
            txt.Background = Brushes.Transparent;
            txt.Foreground = Brushes.White;
            txt.FontSize = 34;
            txt.FontFamily = new FontFamily("Arial Black");
            txt.FontStyle = FontStyles.Normal;
        }
        public void SetBackground()
        {
            ImageBrush background = new ImageBrush(new BitmapImage(new Uri(@"D:\appIcons\background\back.png", UriKind.Relative)));
            parent.Background = background;
        }

        public void SetImg(Image img)
        {
            BitmapImage sunny = new BitmapImage(new Uri(@"D:\appIcons\weatherIcons\sun\sunny.png"));
            BitmapImage moon = new BitmapImage(new Uri(@"D:\appIcons\weatherIcons\moon\moon.png"));
            BitmapImage partlyCloudMoon = new BitmapImage(new Uri(@"D:\appIcons\weatherIcons\moon\partlyCloudMoon.png"));
            BitmapImage mistMoon = new BitmapImage(new Uri(@"D:\appIcons\weatherIcons\moon\mistMoon.png"));
            BitmapImage drizzleMoon = new BitmapImage(new Uri(@"D:\appIcons\weatherIcons\moon\drizzleMoon.png"));
            BitmapImage partlyCloudy = new BitmapImage(new Uri(@"D:\appIcons\weatherIcons\sun\partlyCloudy.png"));
            BitmapImage cloudy = new BitmapImage(new Uri(@"D:\appIcons\weatherIcons\cloud\cloud.png"));
            BitmapImage overcast = new BitmapImage(new Uri(@"D:\appIcons\weatherIcons\cloud\overcast.png"));
            BitmapImage mist = new BitmapImage(new Uri(@"D:\appIcons\weatherIcons\sun\mist.png"));
            BitmapImage rain = new BitmapImage(new Uri(@"D:\appIcons\weatherIcons\rain\rain.png"));
            BitmapImage drizzle = new BitmapImage(new Uri(@"D:\appIcons\weatherIcons\sun\drizzle.png"));
            BitmapImage light = new BitmapImage(new Uri(@"D:\appIcons\weatherIcons\cloud\lightCloud.png"));
            BitmapImage snow = new BitmapImage(new Uri(@"D:\appIcons\weatherIcons\cloud\snowCloud.png"));
            BitmapImage image = null;
            switch (WeatherCondition)
            {
                case "Sunny":
                    if (dt.Hour >= 22 && dt.Hour < 5) image = moon;
                    else image = sunny;
                    break;
                case "Partly cloudy":
                    if (dt.Hour >= 22 && dt.Hour < 5) image = partlyCloudMoon;
                    else image = partlyCloudy;
                    break;
                case "Cloudy":
                    image = cloudy;
                    break;
                case "Overcast":
                    image = overcast;
                    break;
                case "Mist":
                    if (dt.Hour >= 22 && dt.Hour < 5) image = mistMoon;
                    else image = mist;
                    break;
                case "Rain":
                    if (dt.Hour >= 22 && dt.Hour < 5) image = drizzleMoon;
                    else image = drizzle;
                    break;
                case "Drizzle":
                    if (dt.Hour >= 22 && dt.Hour < 5) image = drizzleMoon;
                    else image = drizzle;
                    break;
                case "Showers":
                    image = rain;
                    break;
                case "Thunderstorm":
                    image = light;
                    break;
                case "Snow":
                    image = snow;
                    break;
                case "Blizzard":
                    image = snow;
                    break;
                default:
                    break;
            }
            img.Source = image;
        }

        public void GetInfoAboutWeather()
        {
            string city = "Kiev";
            string apiUrl = $"https://api.weatherapi.com/v1/forecast.json?key={myAPI}&q={city}&days=1";
            HttpResponseMessage response = client.GetAsync(apiUrl).Result;
            string jsonResponse = response.Content.ReadAsStringAsync().Result;
            JsonDocument doc = JsonDocument.Parse(jsonResponse);
            WeatherCondition = doc.RootElement.GetProperty("current").GetProperty("condition").GetProperty("text").GetString();
            Temperature = (int)doc.RootElement.GetProperty("current").GetProperty("temp_c").GetSingle();
            //MessageBox.Show(WeatherCondition);
        }
        
    }
}
