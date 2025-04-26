using System.Text;
using System.Text.Json;
namespace MauiApp3.Pages.Farmers
{

	public partial class ContactUsPage : ContentPage
	{
        private readonly HttpClient _httpClient = new HttpClient();

        private static readonly string _baseUrl =
#if ANDROID
       "http://10.0.2.2:5140/api";
#else
        "https://localhost:7168/api"; 
#endif

        public ContactUsPage()
        {
            InitializeComponent();
        }

        private async void SendButton_Clicked(object sender, EventArgs e)
        {
            string email = EmailEntry.Text?.Trim();
            string message = MessageEditor.Text?.Trim();

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(message))
            {
                await DisplayAlert("خطأ", "يرجى تعبئة جميع الحقول", "موافق");
                return;
            }

            var requestBody = new
            {
                Email = email,
                Question1 = message
            };

            var json = JsonSerializer.Serialize(requestBody);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var response = await _httpClient.PostAsync($"{_baseUrl}/questions", content);

                if (response.IsSuccessStatusCode)
                {
                    await DisplayAlert("نجاح", "تم إرسال رسالتك بنجاح", "موافق");
                    EmailEntry.Text = string.Empty;
                    MessageEditor.Text = string.Empty;
                }
                else
                {
                    await DisplayAlert("خطأ", $"فشل في إرسال الرسالة: {response.StatusCode}", "موافق");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("خطأ", $"حدث خطأ أثناء الإرسال: {ex.Message}", "موافق");
            }
        }
    }
}