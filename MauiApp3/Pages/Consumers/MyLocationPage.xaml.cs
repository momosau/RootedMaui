using Newtonsoft.Json;

namespace MauiApp3.Pages.Consumers;

public partial class MyLocationPage : ContentPage

{
    private readonly HttpClient _httpClient = new HttpClient();
#if ANDROID
        private const string ApiUrl = "http://10.0.2.2:5140/api/Consumers";
#else
    private const string ApiUrl = "https://localhost:7168/api/Consumers";
#endif
    public MyLocationPage()
	{
		InitializeComponent();
        LoadConsumerAddress();

    }
    private async void LoadConsumerAddress()
    {
        try
        {
            var consumerId = Preferences.Get("ConsumerId", 1);
            if (consumerId == 0)
            {
                await DisplayAlert("خطأ", "لم يتم العثور على معلومات المستهلك", "موافق");
                return;
            }

            var response = await _httpClient.GetAsync($"{ApiUrl}/{consumerId}");
            if (!response.IsSuccessStatusCode)
            {
                await DisplayAlert("خطأ", "فشل في تحميل البيانات", "موافق");
                return;
            }

            var json = await response.Content.ReadAsStringAsync();
            var consumer = JsonConvert.DeserializeObject<Consumer>(json);

            if (consumer != null)
            {
                CityLabel.Text = $"المدينة: {consumer.City}";
                NeighborhoodLabel.Text = $"الحي: {consumer.Neighborhood}";
                StreetLabel.Text = $"الشارع: {consumer.Street}";
                HouseNumLabel.Text = $"رقم المنزل: {consumer.HouseNum}";
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("خطأ", $"حدث خطأ: {ex.Message}", "موافق");
        }
    }
    private async void addLoc(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("LocationPage");


    }
    private async void NextCard(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("PaymentMethodPage");

    
    }

 
}