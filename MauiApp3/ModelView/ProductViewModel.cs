using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

using MauiApp3.Pages;
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
        public ICommand DeleteProductCommand { get; }
        public ICommand UpdateProductCommand { get; }

        public ProductViewModel()
        {
            _productService = new ProductService1();
            AddProductCommand = new Command(OnAddProduct);
            DeleteProductCommand = new Command<Product>(OnDeleteProduct);
            UpdateProductCommand = new Command<Product>(OnUpdateProduct);
            LoadProducts();
        }

        private async void LoadProducts()
        {
           var products = await _productService.GetAllProductsAsync();
            Products.Clear();
          foreach (var product in products)
            {
             Products.Add(product);
            }
        }

        private async void OnAddProduct()
        {
            var newProduct = new Product { Name = "Sample", Price = 10.99, Category = "Fruit", Weight = 1.5, ImageUrl = "https://example.com/image.jpg" };
            await _productService.AddProductAsync(newProduct);
            LoadProducts();
        }

        private async void OnUpdateProduct(Product product)
        {
            if (await _productService.UpdateProductAsync(product))
            {
                LoadProducts();
            }
        }

        private async void OnDeleteProduct(Product product)
        {
            if (await _productService.DeleteProductAsync(product.ProductId))
            {
                Products.Remove(product);
            }
        }
    }
}