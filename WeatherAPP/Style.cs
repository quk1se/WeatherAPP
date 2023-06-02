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

namespace WeatherAPP
{
    internal class Style
    {
        DateTime dt = DateTime.Now;
        public MainWindow parent;
        public Style(MainWindow parent)
        {
            this.parent = parent;
        }

        public void ShowDate(TextBlock txt)
        {
            txt.Background = Brushes.Transparent;
            if ((dt.Hour >= 12 && dt.Hour < 17) || (dt.Hour >= 17 && dt.Hour < 22))
                txt.Foreground = Brushes.Black;
            else txt.Foreground = Brushes.White;
            txt.FontSize = 28;
            txt.FontFamily = new FontFamily("Segoe UI");
            txt.FontStyle = FontStyles.Normal;
            txt.Text = dt.DayOfWeek.ToString().ToUpper();
        }
        public void SetBackground()
        {
            ImageBrush backGroundMrn = new ImageBrush(new BitmapImage(new Uri(@"D:\appIcons\background\backmorn.png", UriKind.Relative)));
            ImageBrush backGroundNght = new ImageBrush(new BitmapImage(new Uri(@"D:\appIcons\background\backni.png", UriKind.Relative)));
            ImageBrush backGroundEvng = new ImageBrush(new BitmapImage(new Uri(@"D:\appIcons\background\backevn.png", UriKind.Relative)));
            ImageBrush backGroundDay = new ImageBrush(new BitmapImage(new Uri(@"D:\appIcons\background\backda.png", UriKind.Relative)));
            if (parent != null)
            {
                if (dt.Hour >= 5 && dt.Hour < 12)
                    parent.Background = backGroundMrn;
                else if (dt.Hour >= 12 && dt.Hour < 17)
                    parent.Background = backGroundDay;
                else if (dt.Hour >= 17 && dt.Hour < 22)
                    parent.Background = backGroundEvng;
                else if (dt.Hour >= 22 || dt.Hour < 5)
                    parent.Background = backGroundNght;
            }

        }
    }
}
