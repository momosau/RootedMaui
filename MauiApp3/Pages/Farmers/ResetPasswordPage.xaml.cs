using System.Net.Http.Json;
using SharedLibraryy.Models;

namespace MauiApp3.Pages.Farmers;

public partial class ResetPasswordPage : ContentPage
{
    private bool PasswordVisible = false;
    private string _email;
#if ANDROID
        private const string apiUrl = "http://10.0.2.2:5140/api/Farmers/ResetPassword";
#else
    private const string apiUrl = "https://localhost:7168/api/Farmers/ResetPassword";
#endif
    private readonly HttpClient _httpClient = new HttpClient();
    public ResetPasswordPage(string email)
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
        var Password = passwordEntryNew.Text;
        var confirmPassword = passwordEntryConf.Text;

        if (string.IsNullOrWhiteSpace(Password) || string.IsNullOrWhiteSpace(confirmPassword))
        {
            await DisplayAlert("خطأ", "يرجى تعبئة كلا الحقلين", "موافق");
            return;
        }

        if (Password != confirmPassword)
        {
            await DisplayAlert("خطأ", "كلمة المرور غير متطابقة", "موافق");
            return;

        }

        var ResetPassword = new ResetPasswordRequest
        {
            Email = _email,
            Password = Password
        };

        var response = await _httpClient.PostAsJsonAsync(apiUrl, ResetPassword);
        if (response.IsSuccessStatusCode)
        {
            await DisplayAlert("تم", "تم تغيير كلمة المرور بنجاح", "موافق");
            await Navigation.PopToRootAsync(); // يرجع لصفحة الدخول
        }
        else
        {
            var error = await response.Content.ReadAsStringAsync();
            await DisplayAlert("خطأ", error, "موافق");
        }
    }

    private void Button_Clicked(object sender, EventArgs e)
    {

    }
}

public class ResetPasswordRequest
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}

