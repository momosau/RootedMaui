using MauiApp3.ModelView;

namespace MauiApp3.Pages;

public partial class ShoppingCart : ContentPage
{
	private readonly CartViewModel _cartViewModel;
	public ShoppingCart(CartViewModel cartViewModel)
	{
		InitializeComponent();
		_cartViewModel = cartViewModel;
		BindingContext=_cartViewModel;
    }
}