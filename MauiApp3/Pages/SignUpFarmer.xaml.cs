namespace MauiApp3.Pages;

public partial class SignUpFarmer : ContentPage
{
    private bool PasswordVisible1 = false;
    public SignUpFarmer()
	{
		InitializeComponent();
	}
    private void EyeClicked1(object sender, EventArgs e)
    {
        PasswordVisible1 = !PasswordVisible1;
        passwordEntry1.IsPassword = !PasswordVisible1;
        eyeButton1.Source = PasswordVisible1 ? "eyeo.png" : "eyec.png";
    }

    private async void NextSignUp(object sender, EventArgs e)
    {

        await Shell.Current.GoToAsync("SignUpFarmer2");
    }
  
}