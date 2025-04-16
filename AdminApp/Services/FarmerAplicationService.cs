using SharedLibraryy.Models;
using System.Text.Json;

namespace AdminApp.Services
{
    public class FarmerApilicationService : IFarmerApplicationService
    {
        private readonly HttpClient _httpClient;

        private static readonly string _baseUrl =
#if ANDROID
       "http://10.0.2.2:7168/api";
#else
        "https://localhost:7168/api"; 
#endif
        public FarmerApilicationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Get applications with specifications like status, sorting, pagination
        public async Task<IEnumerable<FarmerApplication>> GetApplicationsAsync(bool? isVerified = null)
        {
            string url = _baseUrl + "/FarmerApplications";

            if (isVerified.HasValue)
            {
                url += $"?isVerified={isVerified.Value.ToString().ToLower()}";
            }

            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<FarmerApplication>>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }



        public async Task<FarmerApplication> GetApplicationByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/FarmerApplications/{id}");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<FarmerApplication>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task ApproveApplicationAsync(int id)
        {
            var response = await _httpClient.PostAsync($"{_baseUrl}/FarmerApplications/{id}/accept", null);
            if (!response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Error: {response.StatusCode}, Content: {content}");
            }
            response.EnsureSuccessStatusCode();
        }

        public async Task RejectApplicationAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{_baseUrl}/FarmerApplications/{id}/reject");
            response.EnsureSuccessStatusCode();
        }
    }
}
