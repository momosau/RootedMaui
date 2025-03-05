namespace MauiApp3.Pages;

public partial class FarmerOrders : ContentPage
{
	public FarmerOrders()
	{
		InitializeComponent();
        BindingContext = new ModelView.FarmerOrdersViewModel();
    }
}