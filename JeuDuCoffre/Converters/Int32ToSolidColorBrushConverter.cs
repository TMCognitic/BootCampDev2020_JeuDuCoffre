using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace JeuDuCoffre.Converters
{
    public class Int32ToSolidColorBrushConverter : IValueConverter
    {
        private Color[] _colors;

        public Int32ToSolidColorBrushConverter()
        {
            _colors = new Color[] { Colors.Blue, Colors.Yellow, Colors.Red, Colors.Green };
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is int i && i > 0 && i < 5)
            {
                return new SolidColorBrush(_colors[i - 1]);
            }

            return Binding.DoNothing;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
