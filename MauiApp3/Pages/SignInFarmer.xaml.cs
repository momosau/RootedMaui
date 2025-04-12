using System;
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.Maui.Controls;

namespace MauiApp3.Pages;

public partial class SignInFarmer : ContentPage
{

    private bool PasswordVisible = false;
    private const string apiKey = "http://localhost:7168/api/Farmers/Login";
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
            await Navigation.PushAsync(new FarmerHome());
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

    public int FarmerId { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}

