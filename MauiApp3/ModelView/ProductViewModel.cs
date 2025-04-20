using CommunityToolkit.Mvvm.ComponentModel;
using MauiApp3.Pages.Farmers;
using MauiApp3.Services;
using SharedLibraryy.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MauiApp3.ModelView
{
    public partial class ProductViewModel : ObservableObject
    {
        private readonly ProductService1 _productService;
        public ObservableCollection<Product> Products { get; set; } = new();

        public ICommand AddProductCommand { get; }
        public ICommand EditProductCommand { get; }
        public ICommand DeleteProductCommand { get; }

        public ProductViewModel()
        {
            _productService = new ProductService1();
            AddProductCommand = new Command(async () => await GoToAddProduct());
            EditProductCommand = new Command<Product>(async (product) => await GoToEditProduct(product));
            DeleteProductCommand = new Command<Product>(async (product) => await DeleteProduct(product));
        }

        public async Task LoadProducts()
        {
            Products.Clear();
            var products = await _productService.GetProducts();
            foreach (var product in products)
            {
                Products.Add(product);
            }
        }

        private async Task GoToAddProduct()
        {
            // Navigate to AddProductsFarmer without parameters
            await Shell.Current.GoToAsync(nameof(Pages.Farmers.AddProductsFarmer));
        }

        private async Task GoToEditProduct(Product product)
        {
            // Navigate to AddProductsFarmer with Product as a parameter
            var parameters = new Dictionary<string, object>
            {
                { "Product", product }
            };
            await Shell.Current.GoToAsync(nameof(AddProductsFarmer), parameters);
        }

        private async Task DeleteProduct(Product product)
        {
            await _productService.DeleteProduct(product.ProductId);
            await LoadProducts(); // Refresh list
        }
    }
}
