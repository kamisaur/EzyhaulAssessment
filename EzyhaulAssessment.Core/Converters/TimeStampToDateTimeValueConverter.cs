using EzyhaulAssessment.Core.Models;
using MvvmCross.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace EzyhaulAssessment.Core.Converters
{
    public class TimeStampToDateTimeValueConverter : MvxValueConverter<double, string>
    {
        protected override string Convert(double value, Type targetType, object parameter, CultureInfo culture)
        {
            var offer = parameter as OfferDetail;
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            try
            {
                dtDateTime = dtDateTime.AddMilliseconds(value).ToLocalTime();

                //string format = $"{offer.dateFormat} {offer.timeFormat}";
                //return dtDateTime.ToString(format);
                return dtDateTime.ToString("dd MMM, yyyy HH:mm");

            }
            catch (Exception)
            {
                return "Undefined";
            }


        }
    }
}
