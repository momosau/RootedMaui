using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace MauiApp3.Pages.Consumers;

public partial class SignUpConsumer : ContentPage
{
    private bool PasswordVisible1 = false;


    public SignUpConsumer()
    {
        InitializeComponent();
    }

    private void EyeClicked(object sender, EventArgs e)
    {
        PasswordVisible1 = !PasswordVisible1;
        passwordEntry.IsPassword = !PasswordVisible1;
        eyeButton.Source = PasswordVisible1 ? "eyeo.png" : "eyec.png";
    }


    private async void NextClicked(object sender, EventArgs e)
    {
        try
        {
            // التحقق من إدخال جميع الحقول
            if (string.IsNullOrWhiteSpace(fullNameEntry.Text) ||
                string.IsNullOrWhiteSpace(phoneNumberEntry.Text) ||
                string.IsNullOrWhiteSpace(emailEntry.Text) ||
                string.IsNullOrWhiteSpace(passwordEntry.Text) ||
                string.IsNullOrWhiteSpace(LocationEntry.Text) ||
                string.IsNullOrWhiteSpace(usernameEntry.Text))

            {
                await DisplayAlert("خطأ", "يرجى ملء جميع الحقول ورفع الصورة", "موافق");
                return;
            }

            var consumer = new Consumer
            {
                ConsumerId = 0,
                Name = fullNameEntry.Text,
                PhoneNumber = phoneNumberEntry.Text,
                Email = emailEntry.Text,
                Password = passwordEntry.Text,
                UserNamer = usernameEntry.Text,
                City = LocationEntry.Text,


            };
            await Navigation.PushAsync(new CEmailVerification(consumer));

        }
        catch (Exception ex)
        {
            await DisplayAlert("خطأ", $"حدث خطأ: {ex.Message}", "موافق");
            Console.WriteLine($"Error: {ex}");
        }
    }
}




public partial class Consumer
{
    public int ConsumerId { get; set; }

    public string Name { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string City { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string UserNamer { get; set; } = null!;

}