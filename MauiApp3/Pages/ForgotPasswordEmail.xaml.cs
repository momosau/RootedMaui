namespace MauiApp3.Pages;

public partial class ForgotPasswordEmail : ContentPage
{
	public ForgotPasswordEmail()
	{
		InitializeComponent();
	}

    private async void SendV(object sender, EventArgs e)
    {
       
        await Shell.Current.GoToAsync("VerificationCodePage");

    }
}