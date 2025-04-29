using Microsoft.Maui.ApplicationModel.Communication;
using Microsoft.Maui.Controls;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using SharedLibraryy.Models;


namespace MauiApp3.Pages.Farmers;

public partial class ForgotPasswordEmail : ContentPage
{
#if ANDROID
        private const string apiUrl = "http://10.0.2.2:5140/api/Farmers/ForgotPassword";
#else
    private const string apiUrl = "https://localhost:7168/api/Farmers/ForgotPassword";
#endif
    private readonly HttpClient _httpClient = new HttpClient();
    public ForgotPasswordEmail()
    {
        InitializeComponent();
    }



    private async void SendV(object sender, EventArgs e)
    {
        var ForgotPassword = new RequestForgotPassword
        {
            Email = EmailEntry.Text,
        };

        var response = await _httpClient.PostAsJsonAsync(apiUrl, ForgotPassword);
        if (response.IsSuccessStatusCode)
        {
            var farmer = await response.Content.ReadFromJsonAsync<Farmer>();
            await Shell.Current.Navigation.PushAsync(new VerificationCodePage(EmailEntry.Text));

        }
        else
        {
            var errorMessage = await response.Content.ReadAsStringAsync();
            await DisplayAlert("خطأ", errorMessage, "موافق");
        }
    }

}

public class RequestForgotPassword
{
    public string Email { get; set; } = string.Empty;
}

