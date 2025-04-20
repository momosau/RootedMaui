using Microsoft.AspNetCore.Authentication;

namespace MauiApp3.Pages.Farmers;

public partial class AccountPageFarmer : ContentPage
{
	public AccountPageFarmer()
	{
		InitializeComponent();
	}
    private async void GoToProfile(object sender, EventArgs e)
    {

        await Shell.Current.GoToAsync("FarmerProfilePage");

    }


    private async void GoToContactUs(object sender, EventArgs e)
    {
     
        await Shell.Current.GoToAsync("ContactUsPage");
    }

    private async void GoToAboutRooted(object sender, EventArgs e)
    {
      
        await Shell.Current.GoToAsync("AboutUsPage");
    }

    

    private async void GoToPrivacyPolicy(object sender, EventArgs e)
    {
      
        await Shell.Current.GoToAsync("PrivacyPolicyPage");
    }

    private async void GoToHome(object sender, EventArgs e)
    {
     
        await Shell.Current.GoToAsync("FarmerHome");
    }

    private async void GoToChatbot(object sender, EventArgs e)
    {

        await Shell.Current.GoToAsync("Chatbot");
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

