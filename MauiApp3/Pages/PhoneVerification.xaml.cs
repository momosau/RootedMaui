namespace MauiApp3.Pages;

public partial class PhoneVerification : ContentPage
{
	public PhoneVerification()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SplashFarmerFinal());

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
}