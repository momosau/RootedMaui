using Refit;
using System.Net.Http;
using System.Net.Http.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using SharedLibraryy.Services;
using SharedLibraryy.Models;


namespace MauiApp3.Services
{
    public class  ApiServices 
    {
        private readonly HttpClient _httpClient;
        private static readonly string _baseUrl =
#if ANDROID
       "http://10.0.2.2:7168/api"; 
#else
        "http://localhost:7168/api"; 
#endif

        public ApiServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<Admin>> GetAdminsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Admin>>($"{_baseUrl}/Admins");
        }

        public async Task<Admin> GetAdminByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Admin>($"{_baseUrl}/Admins/{id}");
        }

        public async Task<bool> CreateAdminAsync(Admin admin)
        {
            var response = await _httpClient.PostAsJsonAsync($"{_baseUrl}/Admins", admin);
            return response.IsSuccessStatusCode;
        }
    }
}
