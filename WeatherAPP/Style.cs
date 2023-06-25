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
using Microsoft.VisualBasic;

namespace WeatherAPP
{
    internal class Style
    {
        DateTime dt = DateTime.Now;
        HttpClient client = new HttpClient();

        public List<string> cityList = new List<string>() {"Kiev", "Kharkov", "Odessa", "Dnepropetrovsk", "Donetsk", "Lviv", "Zaporozhye", "Kryvyi Rih", "Sevastopol", "Nikolaev", "Mariupol",
        "Luhansk", "Makeevka", "Simferopol", "Chernihiv", "Poltava", "Kherson", "Cherkasy"};
        private string weatherCondition;
        private int temperature;
        private int windSpeed;
        private int humidity;
        private int maxTemp;
        private int minTemp;
        private string time;
        public string dateWithTime = DateTime.Now.ToString("yyyy-MM-dd");
        const string myAPI = "54f747b7fcfa4bd7a0142555230206";
        BitmapImage sunny = new BitmapImage(new Uri(@"D:\itstep\winforms\WeatherAPP\WeatherAPP\appIcons\weatherIcons\sun\sunny.png"));
        BitmapImage moon = new BitmapImage(new Uri(@"D:\itstep\winforms\WeatherAPP\WeatherAPP\appIcons\weatherIcons\moon\moon.png"));
        BitmapImage partlyCloudMoon = new BitmapImage(new Uri(@"D:\itstep\winforms\WeatherAPP\WeatherAPP\appIcons\weatherIcons\moon\partlyCloudMoon.png"));
        BitmapImage mistMoon = new BitmapImage(new Uri(@"D:\itstep\winforms\WeatherAPP\WeatherAPP\appIcons\weatherIcons\moon\mistMoon.png"));
        BitmapImage drizzleMoon = new BitmapImage(new Uri(@"D:\itstep\winforms\WeatherAPP\WeatherAPP\appIcons\weatherIcons\moon\drizzleMoon.png"));
        BitmapImage partlyCloudy = new BitmapImage(new Uri(@"D:\itstep\winforms\WeatherAPP\WeatherAPP\appIcons\weatherIcons\sun\partlyCloudy.png"));
        BitmapImage cloudy = new BitmapImage(new Uri(@"D:\itstep\winforms\WeatherAPP\WeatherAPP\appIcons\weatherIcons\cloud\cloud.png"));
        BitmapImage overcast = new BitmapImage(new Uri(@"D:\itstep\winforms\WeatherAPP\WeatherAPP\appIcons\weatherIcons\cloud\overcast.png"));
        BitmapImage mist = new BitmapImage(new Uri(@"D:\itstep\winforms\WeatherAPP\WeatherAPP\appIcons\weatherIcons\sun\mist.png"));
        BitmapImage rain = new BitmapImage(new Uri(@"D:\itstep\winforms\WeatherAPP\WeatherAPP\appIcons\weatherIcons\rain\rain.png"));
        BitmapImage drizzle = new BitmapImage(new Uri(@"D:\itstep\winforms\WeatherAPP\WeatherAPP\appIcons\weatherIcons\sun\drizzle.png"));
        BitmapImage light = new BitmapImage(new Uri(@"D:\itstep\winforms\WeatherAPP\WeatherAPP\appIcons\weatherIcons\cloud\lightCloud.png"));
        BitmapImage snow = new BitmapImage(new Uri(@"D:\itstep\winforms\WeatherAPP\WeatherAPP\appIcons\weatherIcons\cloud\snowCloud.png"));
        BitmapImage rainThunder = new BitmapImage(new Uri(@"D:\itstep\winforms\WeatherAPP\WeatherAPP\appIcons\weatherIcons\cloud\rainThunder.png"));
        BitmapImage windSpeedImg = new BitmapImage(new Uri(@"D:\itstep\winforms\WeatherAPP\WeatherAPP\appIcons\weatherIcons\windSpeed.png"));
        BitmapImage humidityImg = new BitmapImage(new Uri(@"D:\itstep\winforms\WeatherAPP\WeatherAPP\appIcons\weatherIcons\humidity.png"));
        BitmapImage location = new BitmapImage(new Uri(@"D:\itstep\winforms\WeatherAPP\WeatherAPP\appIcons\otherIcons\location.png"));
        BitmapImage maxMin = new BitmapImage(new Uri(@"D:\itstep\winforms\WeatherAPP\WeatherAPP\appIcons\weatherIcons\maxMin.png"));

        public MainWindow parent;
        public string city = "Kiev";

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
        public int WindSpeed
        {
            get { return windSpeed; }
            set { windSpeed = value; }
        }
        public int Humidity
        {
            get { return humidity; }
            set { humidity = value; }
        }
        public int MaxTemp
        {
            get { return maxTemp; }
            set { maxTemp = value; }
        }
        public int MinTemp
        {
            get { return minTemp; }
            set { minTemp = value; }
        }
        public string Time
        {
            get { return time; }
            set { time = value; }
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
            txt.TextAlignment = TextAlignment.Center;
        }
        public void ShowMaxMinTempInfo(TextBlock txt,TextBlock txt2)
        {
            txt.Text = MaxTemp.ToString() + "\u00B0C";
            txt.Background = Brushes.Transparent;
            txt.Foreground = Brushes.White;
            txt.FontSize = 18;
            txt.FontFamily = new FontFamily("Arial Black");
            txt.FontStyle = FontStyles.Normal;
            txt.TextAlignment = TextAlignment.Center;
            txt2.Text = MinTemp.ToString() + "\u00B0C";
            txt2.Background = Brushes.Transparent;
            txt2.Foreground = Brushes.White;
            txt2.FontSize = 18;
            txt2.FontFamily = new FontFamily("Arial Black");
            txt2.FontStyle = FontStyles.Normal;
            txt2.TextAlignment = TextAlignment.Center;
        }
        public void ShowWeatherConditionInfo(TextBlock txt)
        {
            txt.Text = WeatherCondition;
            txt.Background = Brushes.Transparent;
            txt.Foreground = Brushes.White;
            txt.FontSize = 34;
            txt.FontFamily = new FontFamily("Arial Black");
            txt.FontStyle = FontStyles.Normal;
            txt.TextAlignment = TextAlignment.Center; 
        }
        public void SetBackground()
        {
            ImageBrush background = new ImageBrush(new BitmapImage(new Uri(@"D:\itstep\winforms\WeatherAPP\WeatherAPP\appIcons\background\back.png", UriKind.Relative)));
            parent.Background = background;
        }
        public void ShowImgWindRain(Image img,Image img2)
        {
            img.Source = windSpeedImg;
            img2.Source = humidityImg;
        }
        public void ShowLocationImg(Image img)
        {
            img.Source = location;
        }
        public void ShowWindHumidityInfo(TextBlock txt,TextBlock txt2)
        {
            txt.Text = WindSpeed.ToString() + " Kph";
            txt.Background = Brushes.Transparent;
            txt.Foreground = Brushes.White;
            txt.FontSize = 22;
            txt.FontFamily = new FontFamily("Arial Black");
            txt.FontStyle = FontStyles.Normal;
            txt.TextAlignment = TextAlignment.Center;
            txt2.Text = Humidity.ToString() + " %";
            txt2.Background = Brushes.Transparent;
            txt2.Foreground = Brushes.White;
            txt2.FontSize = 22;
            txt2.FontFamily = new FontFamily("Arial Black");
            txt2.FontStyle = FontStyles.Normal;
            txt2.TextAlignment = TextAlignment.Center;
        }
        public void SetComboBox(ComboBox cm)
        {
            cm.Background = Brushes.Black;
            cm.Foreground = Brushes.Black;
            cm.FontSize = 14;
            cm.FontFamily = new FontFamily("Arial Black");
            foreach (var newCity in cityList)
            {
                cm.Items.Add(newCity);
            }
        }
        public void SetMaxMinTemp(Image img)
        {
            img.Source = maxMin;
        }
        public void SetImg(Image img)
        {
            BitmapImage image = null;
            switch (WeatherCondition)
            {
                case "Sunny":
                    if (dt.Hour >= 22 || dt.Hour < 5) image = moon;
                    else image = sunny;
                    break;
                case "Clear":
                    if (dt.Hour >= 22 || dt.Hour < 5) image = moon;
                    else image = sunny;
                    break;
                case "Partly cloudy":
                    if (dt.Hour >= 22 || dt.Hour < 5) image = partlyCloudMoon;
                    else image = partlyCloudy;
                    break;
                case "Cloudy":
                    image = cloudy;
                    break;
                case "Overcast":
                    image = overcast;
                    break;
                case "Light rain":
                    if (dt.Hour >= 22 || dt.Hour < 5) image = drizzleMoon;
                    else image = overcast;
                    break;
                case "Patchy light rain":
                    if (dt.Hour >= 22 || dt.Hour < 5) image = drizzleMoon;
                    else image = overcast;
                    break;
                case "Patchy rain possible":
                    if (dt.Hour >= 22 || dt.Hour < 5) image = drizzleMoon;
                    else image = overcast;
                    break;
                case "Mist":
                    if (dt.Hour >= 22 || dt.Hour < 5) image = mistMoon;
                    else image = mist;
                    break;
                case "Rain":
                    if (dt.Hour >= 22 || dt.Hour < 5) image = drizzleMoon;
                    else image = drizzle;
                    break;
                case "Drizzle":
                    if (dt.Hour >= 22 || dt.Hour < 5) image = drizzleMoon;
                    else image = drizzle;
                    break;
                case "Light drizzle":
                    if (dt.Hour >= 22 || dt.Hour < 5) image = drizzleMoon;
                    else image = drizzle;
                    break;
                case "Patchy light drizzle":
                    if (dt.Hour >= 22 || dt.Hour < 5) image = drizzleMoon;
                    else image = drizzle;
                    break;
                case "Light rain shower":
                    if (dt.Hour >= 22 || dt.Hour < 5) image = rain;
                    else image = rain;
                    break;
                case "Showers":
                    image = rain;
                    break;
                case "Moderate rain":
                    image = rain;
                    break;
                case "Moderate or heavy rain shower":
                    image = rain;
                    break;
                case "Thunderstorm":
                    image = light;
                    break;
                case "Patchy light rain with thunder":
                    image = rainThunder;
                    break;
                case "Thundery outbreaks possible":
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
            string apiUrl = $"https://api.weatherapi.com/v1/forecast.json?key={myAPI}&q={city},UA&days=1";
            HttpResponseMessage response = client.GetAsync(apiUrl).Result;
            string jsonResponse = response.Content.ReadAsStringAsync().Result;
            JsonDocument doc = JsonDocument.Parse(jsonResponse);
            //MessageBox.Show(jsonResponse);
            try { WeatherCondition = doc.RootElement.GetProperty("current").GetProperty("condition").GetProperty("text").GetString(); }
            catch (System.Collections.Generic.KeyNotFoundException ex) { MessageBox.Show("Invalid name of city!"); return; }

            Temperature = (int)doc.RootElement.GetProperty("current").GetProperty("temp_c").GetSingle();
            Humidity = (int)doc.RootElement.GetProperty("current").GetProperty("humidity").GetSingle();
            WindSpeed = (int)doc.RootElement.GetProperty("current").GetProperty("wind_kph").GetSingle();
            MaxTemp = (int)doc.RootElement.GetProperty("forecast").GetProperty("forecastday")[0].GetProperty("day").GetProperty("maxtemp_c").GetDouble();
            MinTemp = (int)doc.RootElement.GetProperty("forecast").GetProperty("forecastday")[0].GetProperty("day").GetProperty("mintemp_c").GetDouble();
        }
        public void GetInfoAboutWeatherWithTime()
        {
            dateWithTime = dateWithTime + " " + Time;
            string apiUrl = $"https://api.weatherapi.com/v1/forecast.json?key={myAPI}&q={city},UA&days=1";
            HttpResponseMessage response = client.GetAsync(apiUrl).Result;
            string jsonResponse = response.Content.ReadAsStringAsync().Result;
            JsonDocument doc = JsonDocument.Parse(jsonResponse);
            JsonElement hourlyData = doc.RootElement.GetProperty("forecast").GetProperty("forecastday")[0].GetProperty("hour");
            foreach (JsonElement hourData in hourlyData.EnumerateArray())
            {
                string tempTime = hourData.GetProperty("time").GetString();
                if (tempTime == dateWithTime)
                {
                    Temperature = (int)hourData.GetProperty("temp_c").GetDouble();
                    Humidity = (int)hourData.GetProperty("humidity").GetDouble();
                    WindSpeed = (int)hourData.GetProperty("wind_kph").GetDouble();
                    WeatherCondition = hourData.GetProperty("condition").GetProperty("text").GetString();
                    break; 
                }
            }
            dateWithTime = DateTime.Now.ToString("yyyy-MM-dd");
        }
        public void UpdateCity()
        {
            ShowTemperatureInfo(parent.Temperature);
            ShowWeatherConditionInfo(parent.WeatherCondition);
            ShowWindHumidityInfo(parent.WindInfo, parent.HumidityInfo);
            ShowDate(parent.DateInfo);
            SetImg(parent.WeatherConditionImg);
            SetMaxMinTemp(parent.MaxMinTempImg);
            ShowMaxMinTempInfo(parent.MaxTempInfo, parent.MinTempInfo);
        }
    }
}
