using SharedLibraryy.Models;
using System.Text;
using System.Text.Json;

namespace MauiApp3.Services
{
    public class ProductService1
    {
        private readonly HttpClient _httpClient;
        private const string ApiUrl = "https://localhost:7168/api/Products";

        public ProductService1()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<Product>> GetProducts()
        {
            try
            {
                var response = await _httpClient.GetStringAsync(ApiUrl);
                return JsonSerializer.Deserialize<List<Product>>(response, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error fetching products: {ex.Message}");
                return new List<Product>(); // Or handle accordingly
            }
        }

        public async Task AddProduct(Product product)
        {
            var json = JsonSerializer.Serialize(product);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(ApiUrl, content);

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"Error: {response.StatusCode}");
            }
        }

        public async Task UpdateProduct(Product product)
        {
            var json = JsonSerializer.Serialize(product);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"{ApiUrl}/{product.ProductId}", content);

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"Error: {response.StatusCode}");
            }
        }

        public async Task DeleteProduct(int productId)
        {
            var response = await _httpClient.DeleteAsync($"{ApiUrl}/{productId}");

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"Error: {response.StatusCode}");
            }
        }
    }
}
