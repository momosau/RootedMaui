using MauiApp3.Services;
using SharedLibraryy.Models;
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

     
            LoadFarmName();
        }

        private async void LoadFarmName()
        {
            if (SelectedProduct == null || SelectedProduct.FarmerId == 0)
                return;

            var farmers = await _productService.GetFarmersAsync();
            var farmer = farmers.FirstOrDefault(f => f.FarmerId == SelectedProduct.FarmerId);
         //   FarmName = farmer?.FarmName;
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
    }

}