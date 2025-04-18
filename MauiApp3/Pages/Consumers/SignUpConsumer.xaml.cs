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
            // «· Õﬁﬁ „‰ ≈œŒ«· Ã„Ì⁄ «·ÕﬁÊ·
            if (string.IsNullOrWhiteSpace(fullNameEntry.Text) ||
                string.IsNullOrWhiteSpace(phoneNumberEntry.Text) ||
                string.IsNullOrWhiteSpace(emailEntry.Text) ||
                string.IsNullOrWhiteSpace(passwordEntry.Text) ||
                string.IsNullOrWhiteSpace(LocationEntry.Text) ||
                string.IsNullOrWhiteSpace(usernameEntry.Text))

            {
                await DisplayAlert("Œÿ√", "Ì—ÃÏ „·¡ Ã„Ì⁄ «·ÕﬁÊ· Ê—›⁄ «·’Ê—…", "„Ê«›ﬁ");
                return;
            }

            var consumer = new Consumer
            {
                Name = fullNameEntry.Text,
                PhoneNumber = phoneNumberEntry.Text,
                Email = emailEntry.Text,
                Password = passwordEntry.Text,
                UserName = usernameEntry.Text,
                Location = LocationEntry.Text,


            };

            await Navigation.PushAsync(new CEmailVerification(consumer));
        }
        catch (Exception ex)
        {
            await DisplayAlert("Œÿ√", $"ÕœÀ Œÿ√: {ex.Message}", "„Ê«›ﬁ");
            Console.WriteLine($"Error: {ex}");
        }
    }
}



public partial class Consumer
{
    public int ConsumerId { get; set; }

    public string Name { get; set; }

    public string PhoneNumber { get; set; }

    public string Location { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public string UserName { get; set; }


}