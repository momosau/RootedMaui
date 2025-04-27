using System;
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.Maui.Controls;

namespace MauiApp3.Pages.Consumers;

public partial class CForgotPassEmail : ContentPage
{


#if ANDROID
        private const string apiUrl = "http://10.0.2.2:5140/api/Consumers/ForgotPassword";
#else
    private const string apiUrl = "https://localhost:7168/api/Consumers/ForgotPassword";
#endif
    private readonly HttpClient _httpClient = new HttpClient();
    public CForgotPassEmail()
    {
        InitializeComponent();
    }


    private async void CheckEmailClicked(object sender, EventArgs e)
    {
        var ForgotPassword = new RequestForgotPassword
        {
            Email = EmailEntry.Text,
        };

        var response = await _httpClient.PostAsJsonAsync(apiUrl, ForgotPassword);
        if (response.IsSuccessStatusCode)
        {
            var consumer = await response.Content.ReadFromJsonAsync<Consumer>();
            await Shell.Current.Navigation.PushAsync(new CVerificationCodePage(EmailEntry.Text));

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



