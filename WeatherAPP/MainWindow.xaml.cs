using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WeatherAPP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Style style;
        public MainWindow()
        {
            InitializeComponent();
            CustomCity.GotFocus += CityList_GotFocus;
            StartAPP();
        }
        public void StartAPP()
        {
            #region Window style
            this.Width = 580;
            this.Height = 820;
            this.Icon = new BitmapImage(new Uri(@"D:\appIcons\iconApp\icon.ico", UriKind.RelativeOrAbsolute));
            this.Title = "Weather APP";
            this.ResizeMode = ResizeMode.NoResize;
            #endregion
            style = new Style(this);
            style.ShowDate(DateInfo);
            style.SetBackground();
            style.GetInfoAboutWeather();
            style.SetImg(WeatherConditionImg);
            style.ShowTemperatureInfo(Temperature);
            style.ShowWeatherConditionInfo(WeatherCondition);
            style.ShowImgWindRain(WindSpeed, RainChance);
            style.ShowWindHumidityInfo(WindInfo, HumidityInfo);
            style.SetComboBox(CityList);
            style.ShowLocationImg(LocationImg);
        }

        private void CityList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CityList.SelectedItem != null)
            {
                string selectedText = CityList.SelectedItem.ToString();
                style.city = selectedText;
            }
            style.UpdateCity();
        }

        private void CustomCity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && style.cityList.Contains(CustomCity.Text) == false)
            {
                style.cityList.Add(CustomCity.Text);
                CityList.Items.Add(CustomCity.Text);
                CustomCity.Text = CustomCity.Text;
                MessageBox.Show("City succesfull add to list");
            }
            else if(e.Key == Key.Enter && style.cityList.Contains(CustomCity.Text))
            {
                CustomCity.Text = CustomCity.Text;
                MessageBox.Show("City already in list");
            }
        }

        private void CityList_GotFocus(object sender, RoutedEventArgs e)
        {
            CustomCity.Text = "Input your city";
        }

    }
}
