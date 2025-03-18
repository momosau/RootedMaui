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

        await Shell.Current.GoToAsync("ForgotPasswordEmail");

    }

    private void eyeClicked(object sender, EventArgs e)
    {
        PasswordVisible = !PasswordVisible;
        passwordEntry.IsPassword = !PasswordVisible;
        eyeButton.Source = PasswordVisible ? "eyeo.png" : "eyec.png";
    }
    private async void SignInClicked(object sender, EventArgs e)
    {
        
        await Shell.Current.GoToAsync("ConsumerMainPage");

    }
}