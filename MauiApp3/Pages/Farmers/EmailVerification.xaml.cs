using System.Diagnostics;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Net.NetworkInformation;

namespace MauiApp3.Pages.Farmers
{
    public partial class EmailVerification : ContentPage
    {
        private FarmerApplication _farmer;
        private const string FixedVerificationCode = "1111";
        private readonly HttpClient _httpClient = new HttpClient();
        private const string apiKey = "http://localhost:7168/api/Farmers";
        //FarmerApplication
        public EmailVerification(FarmerApplication farmer)
        {
            InitializeComponent();
            _farmer = farmer;
            Debug.WriteLine($"تم استقبال بيانات المزارع: {JsonConvert.SerializeObject(_farmer)}");
        }

        private void MoveText(object sender, TextChangedEventArgs e)
        {
            if (sender is Entry currentEntry && !string.IsNullOrEmpty(e.NewTextValue))
            {
               // if (currentEntry == pin1) pin2.Focus();
                //else if (currentEntry == pin2) pin3.Focus();
                //else if (currentEntry == pin3) pin4.Focus();
            }
        }

        private async void VerifyCode(object sender, EventArgs e)
        {
            try
            {
                // التحقق من إدخال جميع الأرقام
                // if (string.IsNullOrEmpty(pin1.Text) || string.IsNullOrEmpty(pin2.Text) ||
                //     string.IsNullOrEmpty(pin3.Text) || string.IsNullOrEmpty(pin4.Text))
                // {
                //    await DisplayAlert("خطأ", "الرجاء إدخال رمز التحقق بالكامل", "موافق");
                    //   return;
                //   }
                //   string enteredCode = $"{pin1.Text}{pin2.Text}{pin3.Text}{pin4.Text}";
                //  if (enteredCode != FixedVerificationCode)
                {
                    await DisplayAlert("خطأ", "كود التحقق غير صحيح", "موافق");
                    return;
                }

             //   loadingIndicator.IsVisible = true;
               // verifyButton.IsEnabled = false;

                // إرسال البيانات إلى API
                bool isSuccess = await UploadFarmerData(_farmer);

                if (isSuccess)
                {
                    await DisplayAlert("نجاح", "تم تسجيل المزارع بنجاح", "موافق");
                    await Navigation.PushAsync(new SplashFarmerFinal());
                }
                else
                {
                    await DisplayAlert("خطأ", "فشل في تسجيل المزارع", "موافق");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("خطأ", $"حدث خطأ غير متوقع: {ex.Message}", "موافق");
                Debug.WriteLine($"Error: {ex}");
            }
            finally
            {
                //loadingIndicator.IsVisible = false;
                //verifyButton.IsEnabled = true;
            }
        }

        private async Task<bool> UploadFarmerData(FarmerApplication farmer)
        {

            try
            {
                // رابط الـ API
                var apiUrl = "http://localhost:7168/api/Farmers"; // ضع عنوان IP المحلي الصحيح هنا
                var json = JsonConvert.SerializeObject(farmer);

                // عرض البيانات المرسلة في الـ Debug
                Debug.WriteLine($"JSON to API: {json}");

                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(apiUrl, content);

                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    Debug.WriteLine($"API Error: {errorContent}");
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Upload Error: {ex}");
                return false;
            }
        }
    }
}
