using System.Diagnostics;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Net.NetworkInformation;

namespace MauiApp3.Pages
{
    public partial class EmailVerification : ContentPage
    {
        private Farmer _farmer;
        private const string FixedVerificationCode = "1111";
        private readonly HttpClient _httpClient = new HttpClient();
        private const string apiKey = "http://localhost:7168/api/Farmers";
        public EmailVerification(Farmer farmer)
        {
            InitializeComponent();
            _farmer = farmer;
            Debug.WriteLine($" „ «” ﬁ»«· »Ì«‰«  «·„“«—⁄: {JsonConvert.SerializeObject(_farmer)}");
        }

        private void MoveText(object sender, TextChangedEventArgs e)
        {
            if (sender is Entry currentEntry && !string.IsNullOrEmpty(e.NewTextValue))
            {
                if (currentEntry == pin1) pin2.Focus();
                else if (currentEntry == pin2) pin3.Focus();
                else if (currentEntry == pin3) pin4.Focus();
            }
        }

        private async void VerifyCode(object sender, EventArgs e)
        {
            try
            {
                // «· Õﬁﬁ „‰ ≈œŒ«· Ã„Ì⁄ «·√—ﬁ«„
                if (string.IsNullOrEmpty(pin1.Text) || string.IsNullOrEmpty(pin2.Text) ||
                    string.IsNullOrEmpty(pin3.Text) || string.IsNullOrEmpty(pin4.Text))
                {
                    await DisplayAlert("Œÿ√", "«·—Ã«¡ ≈œŒ«· —„“ «· Õﬁﬁ »«·ﬂ«„·", "„Ê«›ﬁ");
                    return;
                }
                string enteredCode = $"{pin1.Text}{pin2.Text}{pin3.Text}{pin4.Text}";
                if (enteredCode != FixedVerificationCode)
                {
                    await DisplayAlert("Œÿ√", "ﬂÊœ «· Õﬁﬁ €Ì— ’ÕÌÕ", "„Ê«›ﬁ");
                    return;
                }

                loadingIndicator.IsVisible = true;
                verifyButton.IsEnabled = false;

                // ≈—”«· «·»Ì«‰«  ≈·Ï API
                bool isSuccess = await UploadFarmerData(_farmer);

                if (isSuccess)
                {
                    await DisplayAlert("‰Ã«Õ", " „  ”ÃÌ· «·„“«—⁄ »‰Ã«Õ", "„Ê«›ﬁ");
                    await Navigation.PushAsync(new SplashFarmerFinal());
                }
                else
                {
                    await DisplayAlert("Œÿ√", "›‘· ›Ì  ”ÃÌ· «·„“«—⁄", "„Ê«›ﬁ");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Œÿ√", $"ÕœÀ Œÿ√ €Ì— „ Êﬁ⁄: {ex.Message}", "„Ê«›ﬁ");
                Debug.WriteLine($"Error: {ex}");
            }
            finally
            {
                loadingIndicator.IsVisible = false;
                verifyButton.IsEnabled = true;
            }
        }

        private async Task<bool> UploadFarmerData(Farmer farmer)
        {

            try
            {
                // —«»ÿ «·‹ API
                var apiUrl = "http://localhost:7168/api/Farmers"; // ÷⁄ ⁄‰Ê«‰ IP «·„Õ·Ì «·’ÕÌÕ Â‰«
                var json = JsonConvert.SerializeObject(farmer);

                // ⁄—÷ «·»Ì«‰«  «·„—”·… ›Ì «·‹ Debug
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

