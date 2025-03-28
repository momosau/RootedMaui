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
        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }

}
