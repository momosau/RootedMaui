namespace MauiApp3;

public partial class SplashConsumer : ContentPage
{
    public SplashConsumer()
    {
        InitializeComponent(); 
        NavigationPage.SetHasNavigationBar(this, false);
        
        Task.Delay(4000).ContinueWith(async _ =>
        {
            
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                Navigation.PushAsync(new SignInConsumer());
            });
        });
    }


}
