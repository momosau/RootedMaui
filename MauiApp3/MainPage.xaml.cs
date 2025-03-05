using MauiApp3.Pages;
using Microsoft.Maui.Controls;

namespace MauiApp3
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

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
