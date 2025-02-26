namespace MauiApp3.Pages;

public partial class SplashFarmerFinal : ContentPage
{
	public SplashFarmerFinal()
	{
		InitializeComponent();
        NavigationPage.SetHasNavigationBar(this, false);

        Task.Delay(4000).ContinueWith(async _ =>
        {

            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                Navigation.PushAsync(new MainPage());
            });
        });
    }


}
