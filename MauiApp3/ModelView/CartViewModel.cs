
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SharedLibraryy.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp3.ModelView
{
   public partial class CartViewModel: ObservableObject
    {
        public ObservableCollection<Cart> Cartitem { get; set; } = new();
        private static int _lastCartId = 0;

        [ObservableProperty]
        private int count;
        [RelayCommand]
        public void addToCart(Product product)
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
                    ConsumerId = 1,  
                    Price = (Decimal)product.Price,  
                    Quantity = 1  
                };

                Cartitem.Add(item);
                count=Cartitem.Count;
            }
        }
        [RelayCommand]
        public void removeFromCart(Cart cart)
        {
            var item = Cartitem.FirstOrDefault(c => c.ProductId == cart.ProductId);
            if (item is not null)
            {
                if (item.Quantity == 1)
                {
                    Cartitem.Remove(item);
                    count = Cartitem.Count;
                }
                else
                {
                    item.Quantity--;
                }
            }

        }
        private void ClearCart()
        {
            Cartitem.Clear();
            count = 0;
        }

    }
}
