namespace MauiApp3;

public partial class SignInFarmer : ContentPage
{
    private bool PasswordVisible = false;
    public SignInFarmer()
	{
		InitializeComponent();
	}

    private async void ForgotTapped(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Pages.ForgotPasswordEmail());
       
    }

    private async void RegisterNew(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Pages.SignUpFarmer());

    }

    private void EyeClicked(object sender, EventArgs e)
    {
        PasswordVisible = !PasswordVisible;
        passwordEntry.IsPassword = !PasswordVisible;
        eyeButton.Source = PasswordVisible ? "eyeo.png" : "eyec.png";
    }
}