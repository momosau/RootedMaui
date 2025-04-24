using SharedLibraryy.Models;
using System.Collections.ObjectModel;
using System.Net.Http.Json;

namespace MauiApp3.Pages.Consumers;

public partial class SignInConsumer : ContentPage
{
    private bool PasswordVisible = false;
#if ANDROID
        private const string apiKey = "http://10.0.2.2:5140/api/Consumers/Login";
#else
    private const string apiKey = "http://localhost:7168/api/Consumers/Login";
#endif
    private readonly HttpClient _httpClient = new HttpClient();
    public ObservableCollection<Consumers> Consumer { get; set; } = new ObservableCollection<Consumers>();

    public SignInConsumer()
    {
        InitializeComponent();
    }

    private async void SignInClicked(object sender, EventArgs e)
    {
        try
        {
            var loginRequest = new ConsumerLoginRequest
            {
                Email = EmailEntry.Text?.Trim(),
                Password = PasswordEntry.Text?.Trim()
            };

            var response = await _httpClient.PostAsJsonAsync("http://localhost:5140/api/Consumers/Login", loginRequest);

            if (response.IsSuccessStatusCode)
            {
                var consumer = await response.Content.ReadFromJsonAsync<Consumer>();
                await DisplayAlert("نجاح", $"مرحبًا {consumer?.Name}!", "موافق");
                // توجيه المستخدم للصفحة الرئيسية
           //     await Navigation.PushAsync(new ConsumerHomePage(consumer));
                Application.Current.MainPage = new ConsumerShell();
            }
            else
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                await DisplayAlert("خطأ في تسجيل الدخول", errorMessage, "موافق");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("استثناء", ex.Message, "موافق");
        }
    }

    private async void ForgotTapped(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("CForgotPassEmail");
    }

    private async void RegisterNew(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("SignUpConsumer");
    }

    private void EyeClicked(object sender, EventArgs e)
    {
        PasswordVisible = !PasswordVisible;
        PasswordEntry.IsPassword = !PasswordVisible;
        eyeButton.Source = PasswordVisible ? "eyeo.png" : "eyec.png";
    }
}

public class ConsumerLoginRequest
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}

public class Consumers
{
    public int ConsumerId { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string UserNamer { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Neighborhood { get; set; } = string.Empty;
    public string Street { get; set; } = string.Empty;
    public string HouseNum { get; set; } = string.Empty;
}