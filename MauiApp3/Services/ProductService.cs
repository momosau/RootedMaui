using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace MauiApp3.Services
{
    public class ProductService
    {/*
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "https://localhost:7168/api/Products"; 

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Product>> GetProducts()
        {
            var response = await _httpClient.GetAsync(_baseUrl);
            if (!response.IsSuccessStatusCode)
            {
                return new List<Product>(); // Return empty list on failure
            }

            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<Product>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<Product>();
        }*/
    }

}
