using SharedLibraryy.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp3.Services
{

    public interface ICartService
    {
        ObservableCollection<Cart> GetCart();
        void AddProductToCart(Product product, int quantity);
        Task<List<Cart>> GetCartAsync();
        Task SyncCartToServerAsync(int consumerId);
    }


}

