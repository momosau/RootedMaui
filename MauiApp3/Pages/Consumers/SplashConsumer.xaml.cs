namespace MauiApp3.Pages.Consumers;

public partial class SplashConsumer : ContentPage
{
    public SplashConsumer()
    {
        InitializeComponent(); 
        NavigationPage.SetHasNavigationBar(this, false);
        
        Task.Delay(4000).ContinueWith(async _ =>
        {
            
            await MainThread.InvokeOnMainThreadAsync(async () =>
            {
               
                await Shell.Current.GoToAsync("SignInConsumer");
            });
        });
    }


}
