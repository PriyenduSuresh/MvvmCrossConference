﻿using System;
using System.Net;
using Cirrious.MvvmCross.Converters;

namespace Cirrious.Conference.Core.Converters
{
    public class SimpleDateValueConverter
        : MvxBaseValueConverter
    {
        public override object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var dateValue = (DateTime) value;
            return dateValue.ToString("ddd h:mm");
        }
    }
}