using MauiApp3.ModelView;
using MauiApp3.Pages.Farmers;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Internals;

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
            App.UserType = "farmer";

          // await Navigation.PushAsync(new Pages.Consumers.CForgotPassEmail()); 
          
        Application.Current.MainPage = new FarmerShell();


        }

        private async void Consumerclicked(object sender, EventArgs e)
        {
            App.UserType = "consumer";

          //  await Navigation.PushAsync(new Pages.Consumers.SignUpConsumer());
            Application.Current.MainPage = new ConsumerShell();


        }
    }


}
