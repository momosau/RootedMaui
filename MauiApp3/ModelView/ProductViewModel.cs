using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

using MauiApp3.Pages.Farmers;
using System.Windows.Input;
using System.ComponentModel;
using SharedLibraryy.Models;
using MauiApp3.Services;


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
            await Shell.Current.GoToAsync(nameof(AddProductsFarmer));
        }

        private async Task GoToEditProduct(Product product)
        {
            var parameters = new Dictionary<string, object> { { "Product", product } };
            await Shell.Current.GoToAsync(nameof(AddProductsFarmer), parameters);
        }

        private async Task DeleteProduct(Product product)
        {
            await _productService.DeleteProduct(product.ProductId);
            await LoadProducts(); // Refresh list
        }
    }
}