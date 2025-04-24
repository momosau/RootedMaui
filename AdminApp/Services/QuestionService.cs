using Newtonsoft.Json;
using SharedLibraryy.Models;

namespace AdminApp.Services
{
    public class QuestionService
    {
        private const string ApiUrl =
#if ANDROID
       "http://10.0.2.2:5140/api";
#else
        "https://localhost:7168/api";
#endif
        private readonly HttpClient _httpClient;
        public QuestionService()
        {
            _httpClient = new HttpClient();
        }
        public async Task<List<Question>> GetQuestions()
        {
            var response = await _httpClient.GetStringAsync($"{ApiUrl}/Questions");
            return JsonConvert.DeserializeObject<List<Question>>(response);
        }
    }
}
