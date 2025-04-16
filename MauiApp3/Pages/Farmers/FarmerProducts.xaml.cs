using MauiApp3.ModelView;

namespace MauiApp3.Pages.Farmers;
public partial class FarmerProducts : ContentPage
{
    private readonly ProductViewModel _viewModel;
    public FarmerProducts()
    {


        InitializeComponent();
        BindingContext = _viewModel = new ProductViewModel();
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _viewModel.LoadProducts();
    }
}
