namespace MauiApp3.Pages;

public partial class SplashFarmer : ContentPage
{
	public SplashFarmer()
	{
        InitializeComponent();
        NavigationPage.SetHasNavigationBar(this, false);

        Task.Delay(4000).ContinueWith(async _ =>
        {

            await MainThread.InvokeOnMainThreadAsync(async () =>
            {

                await Shell.Current.GoToAsync("SignInFarmer");
            });
        });
    }


}