using System.Collections.ObjectModel;
using SharedLibraryy.Models;
using MauiApp3.Services;
using System.ComponentModel;
using System.Globalization;
namespace MauiApp3.ModelView
{
    public partial class ProductPageViewModel : BaseViewModel
    {
        private readonly IProductService productService;
        public ObservableCollection<Product> products { get; set; } = new();
        public ObservableCollection<Category> Categories { get; set; } = new();

        public event PropertyChangedEventHandler PropertyChanged;
        public ProductPageViewModel(IProductService productService)
        {

            this.productService = productService;
            Title = "المنتجات";
            GetCategories();
            GetProduct();


        }
        private async void GetCategories()
        {
            var categories = await productService.GetCategoriesAsync();
            if (categories is null || categories.Count == 0)
                return;
            categories.Clear();
            foreach (var category in categories)
            {
                var Newcategory = new Category
                {
                    CategoryId = category.CategoryId,
                    CategoryName = category.CategoryName

                };
                Categories.Add(Newcategory);
            }
        }

        private async void GetProduct()
        {
            var productList = await productService.GetProductAsync();
            if (productList is null || productList.Count == 0)
                return;

            products.Clear();

            foreach (var product in productList)
            {
                var newProduct = new Product
                {
                    ProductId = product.ProductId,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    FarmerId = product.FarmerId,
                    CategoryId = product.CategoryId,
                    Quantity = product.Quantity,
                    Weight = product.Weight,
                    ImageUrl= product.ImageUrl,
                  //  FarmName = product.FarmName
                };

                products.Add(newProduct);
            }
        }

        private string _selectedCategory;
        public string SelectedCategory
        {
            get => _selectedCategory;
            set
            {
                if (_selectedCategory != value)
                {
                    _selectedCategory = value;
                    FilterProducts();
                    OnPropertyChanged(nameof(SelectedCategory));
                    OnPropertyChanged(nameof(FilteredProducts));
                }
            }
        }

        public List<Product> FilteredProducts { get; set; }

        public ProductPageViewModel(string selectedCategory)
        {
            SelectedCategory = selectedCategory;
            FilterProducts();
        }

        private void FilterProducts()
        {
            FilteredProducts = products.Where(p => p.Category == SelectedCategory).ToList();
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



    }
    public class CategoryToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string category && parameter is string selectedCategory)
            {
                return category == selectedCategory ? Colors.Green : Colors.White;
            }
            return Colors.White;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
    }
}