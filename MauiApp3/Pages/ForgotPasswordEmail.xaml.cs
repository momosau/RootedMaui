namespace MauiApp3.Pages;

public partial class ForgotPasswordEmail : ContentPage
{
	public ForgotPasswordEmail()
	{
		InitializeComponent();
	}

    private async void SendV(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Pages.VerificationCodePage());

    }
}