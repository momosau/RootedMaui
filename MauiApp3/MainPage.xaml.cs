using MauiApp3.Pages;
using Microsoft.Maui.Controls;

namespace MauiApp3
{
    public partial class MainPage : ContentPage
    {
        private readonly HttpClient _httpClient;
        public MainPage()
        {
            InitializeComponent();
            _httpClient = new HttpClient();
        }

        private async void GetDataFromApi(object sender, EventArgs e)
        {

            try
            {
                string apiUrl = "https://localhost:7168/api/Admins"; 
                string response = await _httpClient.GetStringAsync(apiUrl);
                label.Text = "API Response: " + response;
            }
            catch (Exception ex)
            {
                label.Text = "Error: " + ex.Message;
            }
        }
        private async void FarmerClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Pages.SplashFarmer());

        }

        private async void Test1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignUpFarmer2());

        }
    }


}
