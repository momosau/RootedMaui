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
            // var httpClient = new HttpClient();
            // var response=await httpClient.GetAsync("https://localhost:7168/api/Farmers'");
            await Navigation.PushAsync(new SplashFarmer());

        }
    }

}
