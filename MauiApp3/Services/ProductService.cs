using SharedLibraryy.Models;
using System.Net.Http.Json;
using System.Text.Json;


namespace MauiApp3.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;
        private readonly string ApiUrl = DeviceInfo.Platform == DevicePlatform.Android
       ? "http://10.0.2.2:5140/"
       : "https://localhost:7168/";

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<Category>> GetCategoriesAsync()
        {
            var categories = await _httpClient.GetAsync($"{ApiUrl}api/Products/Categories");
            var response = await categories.Content.ReadFromJsonAsync<List<Category>>();
            return response;
        }

        public async Task<List<Farmer>> GetFarmersAsync()
        {
            var Farmers = await _httpClient.GetAsync($"{ApiUrl}api/Farmers");
            var response = await Farmers.Content.ReadFromJsonAsync<List<Farmer>>();
            return response;
        }

        public async Task<List<Product>> GetProductAsync()
        {
            var products = await _httpClient.GetAsync($"{ApiUrl}api/Products");
            var response = await products.Content.ReadFromJsonAsync<List<Product>>();
            return response;

        }
        public async Task<List<Review>> GetReviewsAsync(int id)
        {
            var reviews = await _httpClient.GetAsync($"{ApiUrl}api/Reviews/product/{id}");
            var response = await reviews.Content.ReadFromJsonAsync<List<Review>>();
            return response;
        }
        public async Task<Specification> GetProductSpecAsync(int id)
        {
            var product = await _httpClient.GetFromJsonAsync<Product>($"{ApiUrl}api/Products/WithSpec/{id}");
            return product?.Specification;
        }
        public async Task<List<Product>> GetProductsByFarmer(int farmerId)
        {
            var response = await _httpClient.GetAsync($"{ApiUrl}api/Products/farmer/{farmerId}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<List<Product>>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            }

            return new List<Product>();
        }

        public async Task<List<Product>> GetProductsByFarmerIdAsync(int farmerId)
        {
            var response = await _httpClient.GetAsync($"{ApiUrl}api/Products/farmer/{farmerId}");
            if (!response.IsSuccessStatusCode) return new List<Product>();
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<Product>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

    }

}
