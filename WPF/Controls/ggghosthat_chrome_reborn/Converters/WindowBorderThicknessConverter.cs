﻿using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace ggghosthat_chrome_reborn
{
    internal class WindowBorderThicknessConverter : MarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double length = 1;

            if (parameter is string param)
            {
                double.TryParse(param, out length);
            }

            if (value is WindowState windowState)
                return windowState == WindowState.Normal ?
                      new Thickness(length)
                    : new Thickness(0);

            return new Thickness(0);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}
