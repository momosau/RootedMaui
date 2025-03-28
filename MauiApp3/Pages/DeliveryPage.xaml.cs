namespace MauiApp3.Pages;

public partial class DeliveryPage : ContentPage
{
    private int _orderId; // Stores the order ID for fetching details
    public DeliveryPage(int orderId)
	{
        _orderId = orderId; // Stores the order ID in a private field
      //  LoadOrderDetails(); // Calls a function to fetch and display the order details

        InitializeComponent();
	}



}