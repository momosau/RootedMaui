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
            await Navigation.PushAsync(new Pages.SplashFarmer());

        }

        private async void Test1(object sender, EventArgs e)
        {
            //HERE IT GOES FOR THE COUNSUMER SIGN IN  / SIGH UP (MARRRRRRRRIAM)
            //USED TO SEE PAGES
            await Navigation.PushAsync(new Pages.FarmerHome());

        }
    }

}
