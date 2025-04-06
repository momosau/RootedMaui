using CommunityToolkit.Mvvm.Input;
using MauiApp3.ModelView;
using MauiApp3.Services;
using System.ComponentModel;





namespace MauiApp3.Pages
{

    public partial class ProductPage : ContentPage, INotifyPropertyChanged
    {
        public readonly CartViewModel _cartViewModel;


        private int _cartCount;
        public int CartCount
        {
            get => _cartCount;
            set
            {
                if (_cartCount != value)
                {
                    _cartCount = value;
                    OnPropertyChanged(nameof(CartCount));
                }
            }
        }
        public ProductPage(int selectedCategoryId, INavigation navigation, CartViewModel cartViewModel)
        {
            InitializeComponent();
            var httpClient = new HttpClient();
            _cartViewModel = cartViewModel;
            BindingContext = new ProductPageViewModel(selectedCategoryId, new ProductService(httpClient), navigation, cartViewModel);


        }


        [RelayCommand]
        public void AddToCart(int productId) => UpdateToCart(productId, 1);
        [RelayCommand]
        public void RemoveFromCart(int productId) => UpdateToCart(productId, -1);
        public void UpdateToCart(int productId, int count)
        {
            var product = (BindingContext as ProductPageViewModel)?.products.FirstOrDefault(p => p.ProductId == productId);
            if (product is not null)
            {
                product.Quantity += count;
                if (count == -1)
                {
                    _cartViewModel.removeFromCartCommand.Execute(product.ProductId);

                }
                else
                {
                    _cartViewModel.addToCartCommand.Execute(product);
                }

                CartCount = _cartViewModel.Count;
            }

        }
    }
}

