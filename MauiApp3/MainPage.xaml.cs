using Microsoft.Maui.Controls;

namespace MauiApp3
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
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
