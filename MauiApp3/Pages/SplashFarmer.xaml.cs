namespace MauiApp3.Pages;

public partial class SplashFarmer : ContentPage
{
	public SplashFarmer()
	{
        InitializeComponent();
        NavigationPage.SetHasNavigationBar(this, false);
        
        Task.Delay(4000).ContinueWith(async _ =>
        {
            
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                Navigation.PushAsync(new SignInFarmer());
            });
        });
    }


}
