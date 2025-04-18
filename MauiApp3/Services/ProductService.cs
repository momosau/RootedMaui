using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using SharedLibraryy.Models;


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
        public async Task<List<Review>>GetReviewsAsync(int id)
        {
            var reviews = await _httpClient.GetAsync($"{ApiUrl}api/Reviews/product/{id}");
            var response = await reviews.Content.ReadFromJsonAsync<List<Review>>();
            return response;
        }
    }

}
