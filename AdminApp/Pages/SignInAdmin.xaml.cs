using SharedLibraryy.Models;
using System.Collections.ObjectModel;
using System.Net.Http.Json;


namespace AdminApp.Pages;

public partial class SignInAdmin : ContentPage
{
    private bool PasswordVisible = false;
#if ANDROID
        private const string apiKey = "http://10.0.2.2:5140/api/Admins/Login";
#else
    private const string apiKey = "https://localhost:7168/api/Admins/Login";
#endif
    private readonly HttpClient _httpClient = new HttpClient();
    public ObservableCollection<Admin> admins { get; set; } = new ObservableCollection<Admin>();

    public SignInAdmin()
    {
        InitializeComponent();
    }

    private async void SignInClicked(object sender, EventArgs e)
    {
        try
        {
            var loginRequest = new AdminLoginRequest
            {

                //  Email = EmailEntry.Text?.Trim(),
                Email = EmailEntry.Text?.Trim(),
                Password = PasswordEntry.Text?.Trim(),
            };

            var response = await _httpClient.PostAsJsonAsync(apiKey, loginRequest);

            if (response.IsSuccessStatusCode)
            {
                var consumer = await response.Content.ReadFromJsonAsync<SharedLibraryy.Models.Admin>();

              //  UserSession.LoggedInConsumer = consumer;
             //   await DisplayAlert("نجاح", $"مرحبًا {consumer?.Name}!", "موافق");
                // توجيه المستخدم للصفحة الرئيسية
                //     await Navigation.PushAsync(new ConsumerHomePage(consumer));
             
               Application.Current.MainPage = new AppShell();
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
        if (Shell.Current != null)
        {
           // await Shell.Current.GoToAsync(nameof(CForgotPassEmail));
        }
        else
        {
            await DisplayAlert("Navigation Error", "Shell is not ready.", "OK");
        }
    }


  

    private void EyeClicked(object sender, EventArgs e)
    {
        PasswordVisible = !PasswordVisible;
        PasswordEntry.IsPassword = !PasswordVisible;
        eyeButton.Source = PasswordVisible ? "eyeo.png" : "eyec.png";
    }
}

public class AdminLoginRequest
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}

public class Admin
{
    public int AdminId { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}