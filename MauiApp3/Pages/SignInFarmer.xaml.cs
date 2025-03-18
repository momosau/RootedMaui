namespace MauiApp3.Pages;

public partial class SignInFarmer : ContentPage
{
    private bool PasswordVisible = false;
    public SignInFarmer()
	{
		InitializeComponent();
	}

    private async void ForgotTapped(object sender, EventArgs e)
    {


        await Shell.Current.GoToAsync("ForgotPasswordEmail");
    }

    private async void RegisterNew(object sender, EventArgs e)
    {
   
        await Shell.Current.GoToAsync("SignUpFarmer");
    }

    private void EyeClicked(object sender, EventArgs e)
    {
        PasswordVisible = !PasswordVisible;
        passwordEntry.IsPassword = !PasswordVisible;
        eyeButton.Source = PasswordVisible ? "eyeo.png" : "eyec.png";
    }
    private async void SignInClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("FarmerHome");

    }
}