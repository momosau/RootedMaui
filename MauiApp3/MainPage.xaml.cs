
using MauiApp3.Services;
using Microsoft.Maui.Controls;

namespace MauiApp3
{
    public partial class MainPage : ContentPage
    {
        private readonly ApiServices _apiServices;
        public MainPage(ApiServices apiServices)
        {
            InitializeComponent();

            _apiServices = apiServices;
        }

        private async void GetDataFromApi(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Chatbot());

        }

        private async void FarmerClicked(object sender, EventArgs e)

        {

            await Navigation.PushAsync(new Pages.SplashFarmer());

        }

        private async void Test1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Chatbot());

        }

       
        

    }
}
