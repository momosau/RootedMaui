using SharedLibraryy.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiApp3.ModelView;
using MauiApp3.Pages;

namespace MauiApp3.Converter
{
    public class CategoryToColorConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int categoryId)
            {
                var categoriesPage = Application.Current.MainPage.Navigation.NavigationStack
                    .OfType<CategoriesPage>().FirstOrDefault();

                if (categoriesPage == null)
                {
                    Console.WriteLine("Converter: CategoriesPage not found");
                    return Colors.White;
                }

                Console.WriteLine($"Converter: CategoryId={categoryId}, SelectedCategoryId={categoriesPage.SelectedCategoryId}");

                return categoryId == categoriesPage.SelectedCategoryId ? Colors.DarkGreen : Colors.White;
            }

            return Colors.White;
        }


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

    
