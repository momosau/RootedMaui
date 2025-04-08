using CommunityToolkit.Mvvm.ComponentModel;
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
        public ObservableCollection<Cart> Cart { get; set; } = new();

        [ObservableProperty]
        private int count;
        private void addToCart(Product product)
        { 
           // var item = Cart.FirstOrDefault(x => x.ProductId == product.ProductId);
        }

    }
}
