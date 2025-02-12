namespace MauiApp3;

public partial class ResetPasswordPage : ContentPage
{
    private bool PasswordVisible = false;
    public ResetPasswordPage()
	{
		InitializeComponent();
	}

    private void eyeNew(object sender, EventArgs e)
    {
        PasswordVisible = !PasswordVisible;
        passwordEntryNew.IsPassword = !PasswordVisible;
        eyeBtn.Source = PasswordVisible ? "eyeo.png" : "eyec.png";
    }

    private void eyeConf(object sender, EventArgs e)
    {
        PasswordVisible = !PasswordVisible;
        passwordEntryConf.IsPassword = !PasswordVisible;
        eyeBtnConf.Source = PasswordVisible ? "eyeo.png" : "eyec.png";
    }
  

}