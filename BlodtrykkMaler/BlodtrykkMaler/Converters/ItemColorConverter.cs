using BlodtrykkMaler.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace BlodtrykkMaler.Converters
{
    public class ItemColorConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return null;

            var Item = value as Measurement;
            var Sys = Item.Systolic;
            var Dia = Item.Diastolic;

            if (Sys < 120 && Dia < 80)
                return Color.FromHex("#56beea");
            else if (Sys < 129 && Dia < 80)
                return Color.FromHex("#edd06a");
            else if (Sys < 139 || (Dia > 80 && Dia < 89))
                return Color.FromHex("#e7c64b");
            else if ((Sys > 139 && Sys < 180) || Dia > 89)
                return Color.FromHex("#e79b18");
            else if (Sys > 179 || Dia > 119)
                return Color.FromHex("#eb7014");


            return Color.FromHex("#72bdc5");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
