using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp3.Services
{
    using System.Net.Http.Json;
    using SharedLibraryy.Models;
    using Microsoft.Maui.Devices; // Make sure to include this
    using System.Text.Json;

    public class FarmerService
    {
        private readonly HttpClient _httpClient;

        private readonly string ApiUrl = DeviceInfo.Platform == DevicePlatform.Android
            ? "http://10.0.2.2:5140/" // Android emulator localhost
            : "https://localhost:7168/"; // Windows or iOS

        public FarmerService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(ApiUrl)
            };
        }

        public async Task<List<Review>> GetFarmerReviewsAsync(int farmerId)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<List<Review>>($"api/reviews/farmer/{farmerId}");
                return response ?? new List<Review>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching farmer reviews: {ex.Message}");
                return new List<Review>();
            }
        }

        public async Task<List<Farmer>> GetFarmersAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync($"{ApiUrl}api/Farmers");

                var rawContent = await response.Content.ReadAsStringAsync();



                response.EnsureSuccessStatusCode();

                var farmers = JsonSerializer.Deserialize<List<Farmer>>(rawContent, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return farmers ?? new List<Farmer>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($" Error fetching farmers: {ex.Message}");
                return new List<Farmer>();
            }
        }


        public async Task<Farmer> GetFarmerByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"api/farmers/{id}"); // Make sure route matches
            if (!response.IsSuccessStatusCode) return null;
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Farmer>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<int> GetTotalOrdersAsync(int farmerId)
        {
            var response = await _httpClient.GetAsync($"farmers/{farmerId}/orders/total");
            if (!response.IsSuccessStatusCode) return 0;
            var json = await response.Content.ReadAsStringAsync();
            return int.Parse(json);
        }


    }}