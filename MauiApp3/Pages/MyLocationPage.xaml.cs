namespace MauiApp3.Pages;

public partial class MyLocationPage : ContentPage
{
	public MyLocationPage()
	{
		InitializeComponent();
	}

  private async void addLoc(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("LocationPage");


    }
    private async void NextCard(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("PaymentMethodPage");

    
    }

 
}