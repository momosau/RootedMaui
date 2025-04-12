using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiApp3.Services;
using SharedLibraryy.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace MauiApp3.ModelView
{
    public partial class CartViewModel : ObservableObject
    {
        private readonly ICartService _cartService;

        public decimal Amount => Cartitem.Sum(c => c.Price * c.Quantity); 

        public ObservableCollection<Cart> Cartitem { get; set; } = new ObservableCollection<Cart>();

        private static int _lastCartId = 0;

        [ObservableProperty]
        private int count;
        public void RecalculateTotal()
        {
            OnPropertyChanged(nameof(TotalAmount));
        }
        public decimal TotalAmount => Cartitem.Sum(c => c.Amount);

        public CartViewModel(ICartService cartService)
        {
            _cartService = cartService;
        }

        [RelayCommand]
        private void AddToCart(Product product)
        {
            Console.WriteLine($"AddToCart called with product: {product?.Name}");
            var item = Cartitem.FirstOrDefault(c => c.ProductId == product.ProductId);
            if (item is not null)
            {
                item.Quantity++;
            }
            else
            {
                var cartItem = new Cart
                {
                    CartId = ++_lastCartId,
                    ProductId = product.ProductId,
                    ConsumerId = 1, // Ensure this is valid
                    Price = (decimal)product.Price,
                    Quantity = 1,
                    Product = product
                };

                Cartitem.Add(cartItem);
                Count = Cartitem.Count;  // Optional: If you need a separate count property
                OnPropertyChanged(nameof(Amount));
            }
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
                    Count = Cartitem.Count;  // Optional: If you need a separate count property
                }
                else
                {
                    item.Quantity--;
                }
                OnPropertyChanged(nameof(Amount));
            }
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





