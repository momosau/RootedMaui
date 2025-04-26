using MauiApp3.ModelView;
using MauiApp3.Pages.Consumers;
using SharedLibraryy.Models;
using System.Globalization;

namespace MauiApp3.Converter
{
    public class CategoryToColorConverter : IValueConverter
    {


        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var categoryId = (int)value;
            var productPage = parameter as ContentPage;
            var viewModel = productPage?.BindingContext as MauiApp3.ModelView.ProductPageViewModel;

            if (viewModel == null)
                return Colors.White; // default color

            return categoryId == viewModel.SelectedCategoryId ? Colors.LightGreen : Colors.White;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}


