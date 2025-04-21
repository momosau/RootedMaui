namespace MauiApp3.Pages.Farmers;

public partial class FarmerOrders : ContentPage
{
	public FarmerOrders()
	{
		InitializeComponent();
        BindingContext = new ModelView.FarmerOrdersViewModel();
    }
}