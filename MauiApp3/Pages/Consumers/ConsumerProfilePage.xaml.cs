using Microsoft.Maui.Controls;
using Newtonsoft.Json;
using SharedLibraryy.Models;
using System.Net.Http;
using System.Text;
using MauiApp3.Helpers;
using System.Xml;

namespace MauiApp3.Pages.Consumers
{
    public partial class ConsumerProfilePage : ContentPage
    {
        private readonly HttpClient httpClient = new HttpClient();
        private Consumer _consumer;
        private static readonly string _baseUrl =
#if ANDROID
       "http://10.0.2.2:5140/api";
#else
   "https://localhost:7168/api";
#endif
        public ConsumerProfilePage()
        {
            InitializeComponent();
            LoadProfile();
        }

        private async void LoadProfile()
        {
            try
            {
                var consumerId = UserSession.LoggedInConsumer.ConsumerId;

                var response = await httpClient.GetStringAsync($"{_baseUrl}/Consumers/{consumerId}");

                var consumer = JsonConvert.DeserializeObject<Consumer>(response);

                if (consumer != null)
                {
                    nameLabel.Text = consumer.Name;
                    emailLabel.Text = consumer.Email;
                    phoneEntry.Text = consumer.PhoneNumber;
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("خطأ", $"فشل تحميل البيانات: {ex.Message}", "موافق");
            }
        }

        private async void SaveChanges(object sender, EventArgs e)
        {
            try
            {
                var consumerId = UserSession.LoggedInConsumer.ConsumerId;

                var updateRequest = new UpdateConsumerProfileRequest
                {
                    ConsumerId = consumerId,
                    PhoneNumber = phoneEntry.Text
                };

                var json = JsonConvert.SerializeObject(updateRequest);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await httpClient.PutAsync($"{_baseUrl}/Consumers/UpdateConsumerProfile", content);

                if (response.IsSuccessStatusCode)
                    await DisplayAlert("تم", "تم حفظ التعديلات بنجاح", "موافق");
                else
                    await DisplayAlert("خطأ", "فشل حفظ التعديلات", "موافق");
            }
            catch (Exception ex)
            {
                await DisplayAlert("خطأ", $"حدث خطأ أثناء حفظ التعديلات: {ex.Message}", "موافق");
            }
        }
    }

    public class UpdateConsumerProfileRequest
    {
        public int ConsumerId { get; set; }
        public string PhoneNumber { get; set; }
    }
}
