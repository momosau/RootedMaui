using System.Net.Http.Json;

namespace MauiApp3.Pages.Consumers;

public partial class CResetPasswordPage : ContentPage
{
    private bool PasswordVisible = false;
    private string _email;
    private const string apiUrl = "http://localhost:7168/api/Consumer/ResetPassword";
    private readonly HttpClient _httpClient = new HttpClient();
    public CResetPasswordPage(string email)
	{
		InitializeComponent();
        _email = email;

    }


    private void eyeNew(object sender, EventArgs e)
    {
        PasswordVisible = !PasswordVisible;
        passwordEntryNew.IsPassword = !PasswordVisible;
        eyeBtn.Source = PasswordVisible ? "eyeo.png" : "eyec.png";
    }

    private void eyeConf(object sender, EventArgs e)
    {
        PasswordVisible = !PasswordVisible;
        passwordEntryConf.IsPassword = !PasswordVisible;
        eyeBtnConf.Source = PasswordVisible ? "eyeo.png" : "eyec.png";
    }

    private async void ResetPasswordClicked(object sender, EventArgs e)
    {
        var newPassword = passwordEntryNew.Text;
        var confirmPassword = passwordEntryConf.Text;

        if (string.IsNullOrWhiteSpace(newPassword) || string.IsNullOrWhiteSpace(confirmPassword))
        {
            await DisplayAlert("Œÿ√", "Ì—ÃÏ  ⁄»∆… ﬂ·« «·Õﬁ·Ì‰", "„Ê«›ﬁ");
            return;
        }

        if (newPassword != confirmPassword)
        {
            await DisplayAlert("Œÿ√", "ﬂ·„… «·„—Ê— €Ì— „ ÿ«»ﬁ…", "„Ê«›ﬁ");
            return;
        }

        var resetRequest = new ResetPasswordRequest
        {
            Email = _email,
            NewPassword = newPassword
        };

        var response = await _httpClient.PostAsJsonAsync(apiUrl, resetRequest);
        if (response.IsSuccessStatusCode)
        {
            await DisplayAlert(" „", " „  €ÌÌ— ﬂ·„… «·„—Ê— »‰Ã«Õ", "„Ê«›ﬁ");
            await Navigation.PopToRootAsync(); // Ì—Ã⁄ ·’›Õ… «·œŒÊ·
        }
        else
        {
            var error = await response.Content.ReadAsStringAsync();
            await DisplayAlert("Œÿ√", error, "„Ê«›ﬁ");
        }
    }
}

public class ResetPasswordRequest
{
    public string Email { get; set; }
    public string NewPassword { get; set; }
}


