using BlodtrykkMaler.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace BlodtrykkMaler.Converters
{
    public class PressureTextConverter : IValueConverter
    {
        /// <summary>
        /// A converter function that converst data entries to a text specific for that condtion
        /// Eg. low to high bloodpressure is represented with different information
        /// </summary>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return "Er problem har oppstått, kontakt support";

            var Item = value as Measurement;
            var Sys = Item.Systolic;
            var Dia = Item.Diastolic;

            if (Sys < 90 && Dia < 60)
                return "Lavt blodtrykk";
            else if (Sys < 120 && Dia < 80)
                return "Normalt blodtrykk";
            else if (Sys < 130 && Dia < 80)
                return "Hevet blodtrykk (Prehypotensjon)";
            else if (Sys < 140 || (Dia > 80 && Dia < 90))
                return "Høyt blodtrykk (Hypotensjon)";
            else if ((Sys > 140 && Sys < 180) || Dia > 90)
                return "Meget høyt blodtrykk (Hypotensjon)";
            else if (Sys > 180 || Dia > 120)
                return "Veldig høyt blotrykk(Hypotensjon) \nSøk legehjelp umiddelbart";
            else
                return "En feil har oppstått vi har finner ikke ut av verdiene dine";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
