namespace MauiApp3;

public partial class SignInConsumer: ContentPage
{
    private bool PasswordVisible = false;
    public SignInConsumer()
	{
		InitializeComponent();
	}

    private async void ForgotTapped(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ForgotPasswordEmail());
       
    }

  

    private void eyeClicked(object sender, EventArgs e)
    {
        PasswordVisible = !PasswordVisible;
        passwordEntry.IsPassword = !PasswordVisible;
        eyeButton.Source = PasswordVisible ? "eyeo.png" : "eyec.png";
    }
}