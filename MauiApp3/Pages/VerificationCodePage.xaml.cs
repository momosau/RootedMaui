using System.Reflection.Metadata;

namespace MauiApp3;

public partial class VerificationCodePage : ContentPage
{
	public VerificationCodePage()
	{
        InitializeComponent();
	}
   private async void CheckE(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ResetPasswordPage());

    }
    private void MoveText(object sender, TextChangedEventArgs e)
    {
        Entry? currentEntry = sender as Entry;

        if (!string.IsNullOrEmpty(e.NewTextValue))
        {
            if (currentEntry == pin1) pin2.Focus();
            else if (currentEntry == pin2) pin3.Focus();
            else if (currentEntry == pin3) pin4.Focus();
        }

    }
    private string PIN()
    {
        return pin1.Text + pin2.Text + pin3.Text + pin4.Text;
    }
    private void SubmitPin(object sender, EventArgs e)
    {
        string fullPin = PIN();
        DisplayAlert("Entered PIN", "Your PIN is: " + fullPin, "OK");
    }


}