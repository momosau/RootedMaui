using Newtonsoft.Json;
using SharedLibraryy.Models; // Assuming your Consumer model is here
using System.Net.Http;

namespace MauiApp3.Pages.Consumers
{
    public partial class ConsumerProfilePage : ContentPage
    {
        private readonly HttpClient _httpClient = new HttpClient();
#if ANDROID
        private const string ApiUrl = "http://10.0.2.2:5140/api/Consumers";
#else
        private const string ApiUrl = "https://localhost:7168/api/Consumers";
#endif

        public ConsumerProfilePage()
        {
            InitializeComponent();
            LoadConsumerProfile();
        }

        private async void LoadConsumerProfile()
        {
            try
            {
                var consumerId = Preferences.Get("ConsumerId", 1); // Assuming consumerId is stored in preferences
                Console.WriteLine($"Consumer ID: {consumerId}");

                if (consumerId == 0)
                {
                    await DisplayAlert("خطأ", "لم يتم العثور على معلومات المستهلك", "موافق");
                    return;
                }

                var response = await _httpClient.GetAsync($"{ApiUrl}/{consumerId}");
                Console.WriteLine($"API Response Status: {response.StatusCode}");

                if (!response.IsSuccessStatusCode)
                {
                    await DisplayAlert("خطأ", "فشل في تحميل البيانات", "موافق");
                    return;
                }

                var json = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"API Response: {json}");

                var consumer = JsonConvert.DeserializeObject<Consumer>(json);

                if (consumer != null)
                {
                    BindingContext = consumer; // Bind the consumer data to the page
                    Console.WriteLine($"Consumer Loaded: {consumer.Name}");
                }
                else
                {
                    await DisplayAlert("خطأ", "لم يتم العثور على بيانات المستهلك", "موافق");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("خطأ", $"حدث خطأ: {ex.Message}", "موافق");
                Console.WriteLine($"Exception: {ex.Message}");
            }
        }

    }
}