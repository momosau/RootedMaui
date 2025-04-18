using MauiApp3.Services;
using SharedLibraryy.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MauiApp3.ModelView
{
    public class ProductInfoVIewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        private Product _selectedProduct;
        public Product SelectedProduct
        {
            get => _selectedProduct;
            set
            {
                _selectedProduct = value;
                OnPropertyChanged(nameof(SelectedProduct));
                OnPropertyChanged(nameof(FarmName));
            }
        }

        private readonly IProductService _productService;
        private string _farmName;
        public string FarmName
        {
            get => _farmName;
            set
            {
                _farmName = value;
                OnPropertyChanged(nameof(FarmName));
            }
        }

        public ProductInfoVIewModel(Product product, IProductService productService)
        {
            _productService = productService;
            SelectedProduct = product;

            _ = LoadReviewsAsync();
            LoadFarmName();
            getProductspec();
        }

        private async void LoadFarmName()
        {
            if (SelectedProduct == null || SelectedProduct.FarmerId == 0)
                return;

            var farmers = await _productService.GetFarmersAsync();
            var farmer = farmers.FirstOrDefault(f => f.FarmerId == SelectedProduct.FarmerId);
            FarmName = farmer?.FarmName;
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private int _quantityInCart = 1;
        public int QuantityInCart
        {
            get => _quantityInCart;
            set
            {
                if (value != _quantityInCart)
                {
                    _quantityInCart = value;
                    OnPropertyChanged(nameof(QuantityInCart));
                }
            }
        }

        public void IncreaseQuantity()
        {
            if (QuantityInCart < SelectedProduct.Quantity)
                QuantityInCart++;
        }

        public void DecreaseQuantity()
        {
            if (QuantityInCart > 1)
                QuantityInCart--;
        }

        public ObservableCollection<Review> Reviews { get; set; } = new();
       

        private async Task LoadReviewsAsync()
        {
            var reviewsFromService = await _productService.GetReviewsAsync(_selectedProduct.ProductId);
            foreach (var review in reviewsFromService)
                Reviews.Add(review);
        }
        public ObservableCollection<Specification> ProductsSpec { get; set; } = new();

        private async Task getProductspec()
        {
            var spec = await _productService.GetProductSpecAsync(_selectedProduct.ProductId);

            if (spec != null)
            {
                Console.WriteLine($"Spec loaded: IsOrganic = {spec.IsOrganic}, IsGmofree = {spec.IsGmofree}");
                ProductsSpec.Clear();
                ProductsSpec.Add(spec);
            }
            else
            {
                Console.WriteLine("No spec found.");
            }
        }





    }

}