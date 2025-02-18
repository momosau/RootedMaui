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
            await Navigation.PushAsync(new SplashFarmer());
        }

  
    }
}