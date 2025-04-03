
using MauiApp3.ModelView;
using SharedLibraryy.Models;




namespace MauiApp3.Pages;

[QueryProperty(nameof(Product), "Product")]
public partial class AddProductsFarmer : ContentPage
{

    private readonly AddProductViewModel _viewModel;

    public Product Product
    {
        set => _viewModel.SetProduct(value);
    }
    public AddProductsFarmer()
    {
        InitializeComponent();
        BindingContext = _viewModel = new AddProductViewModel();
    }
  
}

   