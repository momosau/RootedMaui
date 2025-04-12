
using SharedLibraryy.Models;
using System.Collections.ObjectModel;
using System.Net.Http.Json;

namespace MauiApp3.Services
{
    public class CartService: ICartService
    {
        private readonly HttpClient _httpClient;
        private readonly string ApiUrl = DeviceInfo.Platform == DevicePlatform.Android
       ? "http://10.0.2.2:5140/"
       : "https://localhost:7168/";
        private ObservableCollection<Cart> _cart = new ObservableCollection<Cart>();

        public ObservableCollection<Cart> GetCart() => _cart;

        public void AddProductToCart(Product product, int quantity)
        {
            var existingItem = _cart.FirstOrDefault(c => c.ProductId == product.ProductId);

            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
                existingItem.Amount = existingItem.Price * existingItem.Quantity;
            }
            else
            {
                _cart.Add(new Cart
                {
                    ProductId = product.ProductId,
                    Product = product,
                    Quantity = quantity,
                    Price = (Decimal)product.Price,
                    Amount = (Decimal)product.Price * quantity
                });
            }
        }

        public CartService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }
        public async Task<List<Cart>> GetCartAsync()
        {
            var response = await _httpClient.GetAsync($"{ApiUrl}api/Carts");
            var cartItems = await response.Content.ReadFromJsonAsync<List<Cart>>();
            return cartItems;

        }

        public async Task SyncCartToServerAsync(int consumerId)
        {
            foreach (var cartItem in _cart)
            {
                var cartToSend = new Cart
                {
                    ConsumerId = consumerId,
                    ProductId = cartItem.ProductId,
                    Quantity = cartItem.Quantity,
                    Price = cartItem.Price,
                    Amount = cartItem.Amount
                };

                await _httpClient.PostAsJsonAsync($"{ApiUrl}api/Carts", cartToSend);
            }
        }

    }
}

