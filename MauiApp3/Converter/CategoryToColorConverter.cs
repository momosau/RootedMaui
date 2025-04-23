using SharedLibraryy.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiApp3.ModelView;
using MauiApp3.Pages.Consumers;

namespace MauiApp3.Converter
{
    public class CategoryToColorConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int categoryId && parameter is int selectedCategoryId)
            {
                // Debug log to check if the values are being passed correctly
                Console.WriteLine($"CategoryId: {categoryId}, SelectedCategoryId: {selectedCategoryId}");

                // Return the color based on the comparison
                return categoryId == selectedCategoryId ? Colors.DarkGreen : Colors.White;
            }

            // If any issue with the input values, return default color
            return Colors.White;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

    
