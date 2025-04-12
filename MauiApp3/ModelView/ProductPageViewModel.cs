using System.Collections.ObjectModel;
using SharedLibraryy.Models;
using MauiApp3.Services;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Input;
using MauiApp3.Pages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
namespace MauiApp3.ModelView
{
    public partial class ProductPageViewModel : INotifyPropertyChanged

    {
        private readonly IProductService productService;

        private readonly INavigation _navigation;
        public ObservableCollection<Product> products { get; set; } = new();
        public ObservableCollection<Category> Categories { get; set; } = new();
        public ObservableCollection<Product> FilteredProducts { get; set; } = new ObservableCollection<Product>();

        public Command<int> ChangeCategoryCommand { get; }
        

        public event PropertyChangedEventHandler PropertyChanged;
        public ProductPageViewModel(int selectedCategoryId, IProductService productService, INavigation navigation)
        {
            this.productService = productService;
            _navigation = navigation;

            SelectedCategoryId = selectedCategoryId;  
            FilterProducts(); 

            ChangeCategoryCommand = new Command<int>(categoryId => SetCategory(categoryId));
            ViewProductCommand = new Command<Product>(OnProductSelected);

            GetCategories(); 
            GetProduct();     
        }



        private void SetCategory(int categoryId)
        {
            if (_selectedCategoryId == categoryId) return;

            _selectedCategoryId = categoryId;
            OnPropertyChanged(nameof(SelectedCategoryId));

            FilterProducts();
        }



        private async void GetCategories()
        {
            var categories = await productService.GetCategoriesAsync();
            if (categories is null || categories.Count == 0)
                return;

            foreach (var category in categories)
            {
                var newCategory = new Category
                {
                    CategoryId = category.CategoryId,
                    CategoryName = category.CategoryName
                };
                Categories.Add(newCategory);  
            }
        }

        private async void GetProduct()
        {
          
            var productList = await productService.GetProductAsync();
            var farmersList = await productService.GetFarmersAsync(); // Fetch all farmers

            if (productList is null || productList.Count == 0)
                return;

            products.Clear();
            foreach (var product in productList)
            {
                // Find the farmer for this product
                var farmer = farmersList.FirstOrDefault(f => f.FarmerId == product.FarmerId);

                products.Add(new Product
                {
                    ProductId = product.ProductId,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    FarmerId = product.FarmerId,
                    Farmer = farmer, // Assign the farmer manually 
                    CategoryId = product.CategoryId,
                    Quantity = product.Quantity,
                    Weight = product.Weight,
                    ImageUrl = product.ImageUrl,
                    Unit = product.Unit
                });
            }

            FilterProducts();
        }

        


        private int _selectedCategoryId;
        public int SelectedCategoryId
        {
            get => _selectedCategoryId;
            set
            {
                _selectedCategoryId = value;
                OnPropertyChanged(nameof(SelectedCategoryId));
            }
        }

      

        public ProductPageViewModel()
        {
            ChangeCategoryCommand = new Command<int>(OnCategoryChanged);
        }

        private void OnCategoryChanged(int categoryId)
        {
            SelectedCategoryId = categoryId; 
            FilterProducts();
        }

        private int _selectedFarmerId;
        public int SelectedFarmerId
        {
            get => _selectedFarmerId;
            set
            {
                if (_selectedFarmerId != value)
                {
                    _selectedFarmerId = value;
                    FilterProducts();
                    OnPropertyChanged(nameof(SelectedFarmerId));
                    OnPropertyChanged(nameof(FilteredProducts));
                }
            }
        }

        private void FilterProducts()
        {
            if (products == null) return;

            var filtered = products
                .Where(p => p.CategoryId == SelectedCategoryId &&
                            (SelectedFarmerId == 0 || p.FarmerId == SelectedFarmerId))
                .ToList();

            FilteredProducts.Clear();
            foreach (var product in filtered)
            {
                FilteredProducts.Add(product);
            }

            OnPropertyChanged(nameof(FilteredProducts));  
        }



        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public Command<Product> ViewProductCommand { get; }



        private async void OnProductSelected(Product product)
        {
            if (product == null)
            {
                Console.WriteLine("Error: Selected product is null");
                return;
            }
            await _navigation.PushAsync(new ProductInfo(product,productService));
        }



    }

}