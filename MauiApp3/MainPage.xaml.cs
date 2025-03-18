using MauiApp3.ModelView;
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
            NavigationPage.SetHasNavigationBar(this, false);
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
          


            await Shell.Current.GoToAsync("SplashFarmer");


        }

        private async void Consumerclicked(object sender, EventArgs e)
        {

            await Shell.Current.GoToAsync("PaymentMethodPage");
           

        }
    }


}
