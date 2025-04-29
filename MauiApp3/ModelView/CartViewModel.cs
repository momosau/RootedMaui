using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiApp3.Services;
using SharedLibraryy.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MauiApp3.ModelView
{
    public partial class CartViewModel : ObservableObject
    {
        private readonly ICartService _cartService;
        public ICommand CloseCommand { get; }

        public decimal Amount => Cartitem.Sum(c => c.Price * c.Quantity);

        public ObservableCollection<Cart> Cartitem { get; set; } = new ObservableCollection<Cart>();

        private static int _lastCartId = 0;

        [ObservableProperty]
        private int count;
        public void RecalculateTotal()
        {
            OnPropertyChanged(nameof(TotalAmount)); // Notify the UI about total amount change
            OnPropertyChanged(nameof(Cartitem));    // Optionally notify about Cartitem collection change
        }

        public decimal TotalAmount => Cartitem.Sum(c => c.Amount);


        public CartViewModel(ICartService cartService)
        {
            _cartService = cartService;
            Cartitem = new ObservableCollection<Cart>(_cartService.GetCart()); 
            CloseCommand = new Command(OnClose);
        }
        [RelayCommand]
        private void AddToCart(Product product)
        {
            Console.WriteLine($"AddToCart called with product: {product?.Name}");
            var item = Cartitem.FirstOrDefault(c => c.ProductId == product.ProductId);

            if (item != null)
            {
                item.Quantity++;
                item.Amount = item.Price * item.Quantity;
            }
            else
            {
                var cartItem = new Cart
                {
                    CartId = ++_lastCartId,
                    ProductId = product.ProductId,
                    ConsumerId = 1,
                    Price = (decimal)product.Price,
                    Quantity = 1,
                    Product = product,
                    Amount = (decimal)product.Price * 1
                };

                Cartitem.Add(cartItem);
            }

            // Always update the cart service
            _cartService.AddProductToCart(product, 1);

            Count = Cartitem.Count;
            OnPropertyChanged(nameof(Amount));
            OnPropertyChanged(nameof(TotalAmount));
        }


        [RelayCommand]
        private void RemoveFromCart(Cart cart)
        {
            var item = Cartitem.FirstOrDefault(c => c.ProductId == cart.ProductId);
            if (item is not null)
            {
                if (item.Quantity == 1)
                {
                    Cartitem.Remove(item);
                    Count = Cartitem.Count;  // Update the count
                    OnPropertyChanged(nameof(Amount)); // Notify the UI for Amount change
                    OnPropertyChanged(nameof(Count)); // Notify the UI for Count change
                }
                else
                {
                    item.Quantity--;
                    OnPropertyChanged(nameof(Amount)); // Recalculate total amount
                }
            }
        }

        private async void OnClose()
        {
            await Shell.Current.Navigation.PopAsync();
        }

        [RelayCommand]
        private void ClearCart()
        {
            Cartitem.Clear();
            Count = 0;
            OnPropertyChanged(nameof(Amount));
        }
    }
}





