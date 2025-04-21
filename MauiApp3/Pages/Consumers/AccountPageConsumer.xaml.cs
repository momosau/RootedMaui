namespace MauiApp3.Pages.Consumers;

public partial class AccountPageConsumer : ContentPage
{
    public AccountPageConsumer()
    {
        InitializeComponent();
    }
    private async void GoToProfile(object sender, EventArgs e)
    {

       await Shell.Current.GoToAsync(nameof(Pages.Consumers.ConsumerProfilePage));

    }


    private async void GoToContactUs(object sender, EventArgs e)
    {

        await Shell.Current.GoToAsync("ContactUsPageC");
    }

    private async void GoToAboutRooted(object sender, EventArgs e)
    {

        await Shell.Current.GoToAsync("AboutUsPageC");
    }



    private async void GoToPrivacyPolicy(object sender, EventArgs e)
    {

        await Shell.Current.GoToAsync("PrivacyPolicyPageC");
    }

    

    private async void SignOut(object sender, EventArgs e)
    {
        bool confirm = await DisplayAlert("تسجيل الخروج", "هل أنت متأكد أنك تريد تسجيل الخروج؟", "نعم", "لا");
        if (confirm)
        {
            //object value = await AuthenticationService.SignOutAsync();
            Application.Current.MainPage = new NavigationPage(new MainPage());


        }
    }
}

