using MauiApp3.ModelView;

namespace MauiApp3.Pages;

public partial class ProductPage : ContentPage
{
	public ProductPage(ProductPageViewModel productPageViewModel)
	{
		InitializeComponent();
		BindingContext=productPageViewModel;
	}
}