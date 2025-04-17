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

        public async Task<List<Farmer>> GetFarmersAsync()
        {
            try
            {
                var farmers = await _httpClient.GetFromJsonAsync<List<Farmer>>("api/farmers");
                return farmers ?? new List<Farmer>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching farmers: {ex.Message}");
                return new List<Farmer>();
            }
        }
    }

}
