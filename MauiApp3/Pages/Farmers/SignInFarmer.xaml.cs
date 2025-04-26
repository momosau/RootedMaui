using System;
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.Maui.Controls;
using SharedLibraryy.Models;

namespace MauiApp3.Pages.Farmers;

public partial class SignInFarmer : ContentPage
{
 

    private bool PasswordVisible = false;
#if ANDROID
        private const string apiKey = "http://10.0.2.2:5140/api/Farmers/Login";
#else
    private const string apiKey = "https://localhost:7168/api/Farmers/Login";
#endif

    private readonly HttpClient _httpClient = new HttpClient();

    public SignInFarmer()
    {
        InitializeComponent();
    }

    private async void SignInClicked(object sender, EventArgs e)
    {
        var loginRequest = new FarmerLoginRequest
        {
            Email = EmailEntry.Text,
            Password = PasswordEntry.Text
        };

        var response = await _httpClient.PostAsJsonAsync(apiKey, loginRequest);
        if (response.IsSuccessStatusCode)
        {
            var farmer = await response.Content.ReadFromJsonAsync<Farmer>();
            await Navigation.PushAsync(new Pages.Farmers.FarmerHome());
        }
        else
        {
            var errorMessage = await response.Content.ReadAsStringAsync();
            await DisplayAlert("Œÿ√", errorMessage, "„Ê«›ﬁ");
        }
    }

    private async void ForgotTapped(object sender, EventArgs e)
    {


        await Shell.Current.GoToAsync("ForgotPasswordEmail");
    }

    private async void RegisterNew(object sender, EventArgs e)
    {

        await Shell.Current.GoToAsync("SignUpFarmer");
    }

    private void EyeClicked(object sender, EventArgs e)
    {
        PasswordVisible = !PasswordVisible;
        
        PasswordEntry.IsPassword = !PasswordVisible;
        eyeButton.Source = PasswordVisible ? "eyeo.png" : "eyec.png";
    }

}

public class FarmerLoginRequest
{


    public string Email { get; set; }
    public string Password { get; set; }
}

