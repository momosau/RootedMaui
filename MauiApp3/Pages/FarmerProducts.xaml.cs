using MauiApp3.ModelView;
using SharedLibraryy.Models;
using MauiApp3.Services;
namespace MauiApp3.Pages;
using MauiApp3.ModelView;

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
