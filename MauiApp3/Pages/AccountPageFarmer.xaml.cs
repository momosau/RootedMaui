using Microsoft.AspNetCore.Authentication;

namespace MauiApp3.Pages;

public partial class AccountPageFarmer : ContentPage
{
	public AccountPageFarmer()
	{
		InitializeComponent();
	}
    private async void GoToProfile(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new FarmerProfilePage());
    }
   

    private async void GoToContactUs(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ContactUsPage());
    }

    private async void GoToAboutRooted(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AboutUsPage());
    }

    private async void GoToPrivacyPolicy(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PrivacyPolicyPage());
    }

    private async void GoToHome(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new FarmerHome());
    }

    private async void GoToChatbot(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Chatbot());
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

