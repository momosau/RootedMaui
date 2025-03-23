using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;
using MauiApp3.ModelView;
using MauiApp3.Services;
using MauiApp3.Models;
using System.Windows.Input;
using SharedLibraryy.Models;
namespace MauiApp3.ModelView
{
    public partial class ProductPageViewModel : BaseViewModel
    {
        private readonly IProductService productService;
        public ObservableCollection<Product> Products { get; set; } = new();
        public ObservableCollection<Product> FilteredProducts { get; set; } = new();
        public ObservableCollection<Category> Categories { get; set; } = new();
        public ObservableCollection<Farmer> Farmers { get; set;} = new();

        private string _selectedCategory = "All"; 

        public ProductPageViewModel(IProductService productService)
        {
            this.productService = productService;
            Title = "المنتجات";
            GetCategories();
            GetProducts();  
           
        }


      

        private async Task GetCategories()
        {
            var categories = await productService.GetCategoriesAsync();
            if (categories is null || categories.Count == 0)
                return;

            Categories.Clear();
            Categories.Add(new Category { CategoryId = 0, CategoryName = "All" });
            foreach (var category in categories)
            {
                Categories.Add(new Category
                {
                    CategoryId = category.CategoryId,
                    CategoryName = category.CategoryName
                });
            }
        }

        private async Task GetProducts()
        {
            var productList = await productService.GetProductAsync();
            if (productList is null || productList.Count == 0)
                return;

            Products.Clear();
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
                    unit = product.unit,
                    Weight = product.Weight,
                    ImageUrl = "Vegetable.png"
                };

                Products.Add(newProduct);
            }

            FilterProducts();
        }



        public string SelectedCategory
        {
            get => _selectedCategory;
            set
            {
                if (_selectedCategory != value)
                {
                    _selectedCategory = value;
                    OnPropertyChanged();
                    FilterProducts();
                }
            }
        }

        private void FilterProducts()
        {
            if (string.IsNullOrEmpty(SelectedCategory) || SelectedCategory == "All")
            {
                FilteredProducts = new ObservableCollection<Product>(Products);
            }
            else
            {
                var filteredList = Products.Where(p => p.CategoryId.ToString() == SelectedCategory).ToList();
                FilteredProducts = new ObservableCollection<Product>(filteredList);
            }

            OnPropertyChanged(nameof(FilteredProducts));
        }
        public async void GetFarmName() {
            var farmers = await productService.GetFarmersAsync();
            if (farmers is null || farmers.Count == 0)
                return;
            Farmers.Clear();
            foreach (var farmer in farmers)
            {
                var newFarmer = new Farmer
                {
                    FarmerId = farmer.FarmerId,
                    Name = farmer.Name,
                    Description = farmer.Description,
                    Certificate = farmer.Certificate,
                    Location = farmer.Location,
                    ImageUrl = farmer.ImageUrl,
                    PhoneNumber = farmer.PhoneNumber,
                    Email = farmer.Email,
                    Password = farmer.Password,
                    VerificationStatus = farmer.VerificationStatus,
                    UserName = farmer.UserName,
                    FarmName= farmer.FarmName
                };
                Farmers.Add(newFarmer);
            }
            
        }
        



    }
}