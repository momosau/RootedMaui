﻿using System;
using System.Globalization;
using Microsoft.Maui.Controls;

namespace MauiApp3.Converter
{
    public class SpecConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool isTrue && parameter is string iconName)
            {
                return isTrue ? $"{iconName}_icon.png" : "default_icon.png";
            }

            return "default_icon.png";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

