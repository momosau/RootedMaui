using Refit;
using System.Net.Http;
using System.Net.Http.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using SharedLibraryy.Services;
using SharedLibraryy.Models;


namespace MauiApp3.Services
{
    public class  ApiServices :IApiServices
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "https://localhost:7168/api";

        public ApiServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<Product>> GetProductsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Product>>($"{_baseUrl}/products");
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Product>($"{_baseUrl}/products/{id}");
        }

        public async Task<bool> CreateProductAsync(Product product)
        {
            var response = await _httpClient.PostAsJsonAsync($"{_baseUrl}/products", product);
            return response.IsSuccessStatusCode;
        }
    }
}
