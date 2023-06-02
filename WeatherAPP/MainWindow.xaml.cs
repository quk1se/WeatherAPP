using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
            StartAPP();
        }
        public void StartAPP()
        {
            #region Title icon
            #endregion
            #region Window style
            this.Width = 580;
            this.Height = 820;
            this.Icon = new BitmapImage(new Uri(@"D:\appIcons\iconApp\icon.ico", UriKind.RelativeOrAbsolute));
            this.Title = "Weather APP";
            #endregion
            style = new Style(this);

        }
    }
}
