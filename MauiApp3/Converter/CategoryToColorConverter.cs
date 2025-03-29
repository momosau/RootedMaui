using SharedLibraryy.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp3.Converter
{
    public class CategoryToColorConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || parameter == null)
                return Colors.White;

            // Safely convert value to int
            if (!int.TryParse(value.ToString(), out int categoryId))
                return Colors.White;

            // Safely convert parameter to int
            if (!int.TryParse(parameter.ToString(), out int selectedCategoryId))
                return Colors.White;

            return categoryId == selectedCategoryId ? Colors.Green : Colors.White;
        }


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                return null;
            }
    }
}
