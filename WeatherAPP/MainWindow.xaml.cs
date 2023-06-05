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
            CustomCity.GotFocus += CustomCity_GotFocus;
            StartAPP();
        }
        public void StartAPP()
        {
            #region Window style
            this.Width = 580;
            this.Height = 820;
            this.Icon = new BitmapImage(new Uri(@"D:\itstep\winforms\WeatherAPP\WeatherAPP\appIcons\iconApp\icon.ico", UriKind.RelativeOrAbsolute));
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
            style.SetMaxMinTemp(MaxMinTempImg);
            style.ShowMaxMinTempInfo(MaxTempInfo,MinTempInfo);
            style.ShowAllTimeBtns(Btn00);
        }
        private void CityList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CityList.SelectedItem != null)
            {
                string selectedText = CityList.SelectedItem.ToString();
                style.city = selectedText;
                style.Time = DateTime.Now.TimeOfDay.ToString(@"hh\:mm");
            }
            style.GetInfoAboutWeather();
            style.UpdateCity();
        }

        private void CustomCity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && style.cityList.Contains(CustomCity.Text) == false)
            {
                style.cityList.Add(CustomCity.Text);
                CityList.Items.Add(CustomCity.Text);
                MessageBox.Show("City succesfull add to list","Succesfull", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if(e.Key == Key.Enter && style.cityList.Contains(CustomCity.Text))
            {
                MessageBox.Show("City already in list","Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CustomCity_GotFocus(object sender, RoutedEventArgs e)
        {
            CustomCity.Text = "";
        }

        private void CustomCity_LostFocus(object sender, RoutedEventArgs e)
        {
            CustomCity.Text = "Input your city";
        }

        private void Btn00_Click(object sender, RoutedEventArgs e)
        {
            style.Time = Btn00.Content.ToString();
            style.GetInfoAboutWeatherWithTime();
            style.UpdateCity();
        }
    }
}
