using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using SharedLibraryy.Models;

namespace MauiApp3.Services
{
    public class ProductService1
    {
        private readonly HttpClient _httpClient;
private const string ApiUrl = "https://localhost:7168/api/Products"; // Replace with your actual API URL
    
        public ProductService1()
        {
            _httpClient = new HttpClient();
        }

       public async Task<List<Product>> GetAllProductsAsync()
       {
           return await _httpClient.GetFromJsonAsync<List<Product>>(ApiUrl) ?? new List<Product>();
       }

        public async Task AddProductAsync(Product product)
        {
            await _httpClient.PostAsJsonAsync(ApiUrl, product);
        }

        public async Task<bool> UpdateProductAsync(Product product)
        {
            var response = await _httpClient.PutAsJsonAsync($"{ApiUrl}/{product.ProductId}", product);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteProductAsync(int productId)
        {
            var response = await _httpClient.DeleteAsync($"{ApiUrl}/{productId}");
            return response.IsSuccessStatusCode;
        }
    }
}