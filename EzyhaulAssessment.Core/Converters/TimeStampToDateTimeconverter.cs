using MvvmCross.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace EzyhaulAssessment.Core.Converters
{
    public class TimeStampToDateTimeconverter : MvxValueConverter<double, DateTime>
    {
        protected override DateTime Convert(double value, Type targetType, object parameter, CultureInfo culture)
        {
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(value).ToLocalTime();
            return dtDateTime;
        }
    }
}
