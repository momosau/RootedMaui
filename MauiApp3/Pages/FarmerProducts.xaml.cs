using MauiApp3.ModelView;
using SharedLibraryy.Models;

namespace MauiApp3.Pages;

public partial class FarmerProducts : ContentPage
{
    private readonly ProductViewModel _viewModel;

    public FarmerProducts(ProductViewModel productViewModel)
    {
        InitializeComponent();
 
        BindingContext = productViewModel; // Bind ViewModel to the page
    }

}
