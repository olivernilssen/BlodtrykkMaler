﻿using BlodtrykkMaler.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace BlodtrykkMaler.Converters
{
    public class ItemColorConverter : IValueConverter
    {

        /// <summary>
        /// A converter function that converst data entries to color
        /// Eg. low to high bloodpressure is represented with different colors
        /// </summary>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return Color.FromHex("#ffffff");

            var Item = value as Measurement;
            var Sys = Item.Systolic;
            var Dia = Item.Diastolic;

            if (Sys < 90 && Dia < 60)
                return (Color)Application.Current.Resources["PLow"];
            else if(Sys < 120 && Dia < 80)
                return (Color)Application.Current.Resources["PNormal"];
            else if (Sys < 130 && Dia < 80)
                return (Color)Application.Current.Resources["PElevated"];
            else if (Sys < 140 || (Dia > 80 && Dia < 90))
                return (Color)Application.Current.Resources["PHigh"];
            else if ((Sys > 140 && Sys < 180) || Dia > 90)
                return (Color)Application.Current.Resources["PHigh2"];
            else if (Sys > 180 || Dia > 120)
                return (Color)Application.Current.Resources["PHyper"];

            return Color.FromHex("#72bdc5");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
