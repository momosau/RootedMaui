using SharedLibraryy.Models;
using System.Net.Http.Json;


namespace MauiApp3.Services
{
    public class ApiServices
    {
        private readonly HttpClient _httpClient;
        private readonly string ApiUrl = DeviceInfo.Platform == DevicePlatform.Android
       ? "http://10.0.2.2:5140/"
       : "https://localhost:7168/";

        public ApiServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<Admin>> GetAdminsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Admin>>($"{ApiUrl}Admins");
        }

        public async Task<Admin> GetAdminByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Admin>($"{ApiUrl}Admins/{id}");
        }

        public async Task<bool> CreateAdminAsync(Admin admin)
        {
            var response = await _httpClient.PostAsJsonAsync($"{ApiUrl}Admins", admin);
            return response.IsSuccessStatusCode;
        }
    }
}
