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

        
        private async void FarmerClicked(object sender, EventArgs e)
        {
          


            await Shell.Current.GoToAsync("SplashFarmer");


        }

        private async void Consumerclicked(object sender, EventArgs e)
        {
            //PaymentMethodPage
            await Shell.Current.GoToAsync("FarmerProducts");
           

        }
    }


}
