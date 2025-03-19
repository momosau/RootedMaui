using MauiApp3.ModelView;
using SharedLibraryy.Models;
using MauiApp3.Services;
namespace MauiApp3.Pages;
using MauiApp3.ModelView;

public partial class FarmerProducts : ContentPage
{

    public FarmerProducts()
    {
        

        InitializeComponent();
        BindingContext = new ProductViewModel();
    }

}
