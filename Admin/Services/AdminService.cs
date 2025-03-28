using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using SharedLibraryy.Models;

namespace Admin.Services
{
    public class AdminService
    {
        private readonly HttpClient _httpClient;
        private static readonly string _baseUrl =
#if ANDROID
       "http://10.0.2.2:7168/api";
#else
        "http://localhost:7168/api"; 
#endif

        public AdminService(HttpClient httpClient)
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
