using AdminApp.Pages;
using AdminApp.Services;
using AdminApp.ViewModel;
namespace AdminApp
{
    public partial class MainPage : ContentPage
    {
        private readonly HttpClient _httpClient;
        int count = 0;

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
        private async void OnCounterClicked(object sender, EventArgs e)
        {
            var httpClient = new HttpClient();
            var viewModel = new AdminApprovalViewModel(new FarmerApilicationService(httpClient)); 
            await Navigation.PushAsync(new AdminApproval(viewModel));


        }
    }

}
