using MauiApp3.Pages;
using Microsoft.Maui.Controls;
using SharedLibraryy.Models;
using MauiApp3.Services;
namespace MauiApp3
{
    public partial class MainPage : ContentPage
    {
        private readonly HttpClient _httpClient;
        public MainPage()
        {
            InitializeComponent();

            _httpClient = new HttpClient();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private async void GetDataFromApi(object sender, EventArgs e)
        {

            try
            {
                string apiUrl =
#if ANDROID
                "http://10.0.2.2:7168/api/Admins"; // Android Emulator
#else
                "https://localhost:7168/api/Admins"; // Windows, iOS, macOS
#endif
                string response = await _httpClient.GetStringAsync(apiUrl);
                labelApi.Text = "API Response: " + response;
            }
            catch (Exception ex)
            {
                labelApi.Text = "Error: " + ex.Message;
            }
        }
        private async void FarmerClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Pages.SplashFarmer());

        }

        private async void Consumerclicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SplashConsumer());

        }
    }


}
