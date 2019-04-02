using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Media;

namespace FormatoEwo.Util
{
    public class BackgroundColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string b = (string)value;
            
            if (b.Equals("A"))// compare  date with your list.  
            {
                return new SolidColorBrush(Colors.Red);
            }
            else if (b.Equals("B"))
            {
                return new SolidColorBrush(Colors.Yellow);
            }
            else if (b.Equals("C"))
            {
                return new SolidColorBrush(Colors.Green);
            }
            else
            {
                return new SolidColorBrush(Colors.White);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
