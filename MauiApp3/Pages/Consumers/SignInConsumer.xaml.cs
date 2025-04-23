using SharedLibraryy.Models;
using System.Net.Http.Json;

namespace MauiApp3.Pages.Consumers;

public partial class SignInConsumer : ContentPage
{
    private bool PasswordVisible = false;
    private const string apiKey = "https://localhost:7168/api/Consumer/Login";
    private readonly HttpClient _httpClient = new HttpClient();
    public SignInConsumer()
    {
        InitializeComponent();
    }


    private async void SignInClicked(object sender, EventArgs e)
    {
        var loginRequest = new ConsumerLoginRequest
        {
            Email = EmailEntry.Text,
            Password = PasswordEntry.Text
        };

        var response = await _httpClient.PostAsJsonAsync(apiKey, loginRequest);
        if (response.IsSuccessStatusCode)
        {
            var consumer = await response.Content.ReadFromJsonAsync<Consumer>();
            await Shell.Current.Navigation.PushAsync(new ConsumerHomePage(consumer));

        }
        else
        {
            var errorMessage = await response.Content.ReadAsStringAsync();
            await DisplayAlert("Œÿ√", errorMessage, "„Ê«›ﬁ");
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

    public int FarmerId { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

}