using System;
using System.Collections.Generic;
using System.Linq;
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
        private readonly HttpClient httpClient;
        public ProductService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<List<Category>> GetCategoriesAsync()
        {
            var categories = await httpClient.GetAsync("https://localhost:7168/api/Products/Categories");
            var response = await categories.Content.ReadFromJsonAsync<List<Category>>();
            return response;
        }

        public async Task<List<Product>> GetProductAsync()
        {
            var products = await httpClient.GetAsync("https://localhost:7168/api/Products");
            var response = await products.Content.ReadFromJsonAsync<List<Product>>();
            return response;

        }

    }

}
