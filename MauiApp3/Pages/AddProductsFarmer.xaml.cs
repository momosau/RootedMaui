
using MauiApp3.ModelView;

using Product = MauiApp3.ModelView.Product;


namespace MauiApp3.Pages;

public partial class AddProductsFarmer : ContentPage
{


    public AddProductsFarmer()
    {
        InitializeComponent();
        BindingContext = new ProductViewModel();
    }
    private void OnProductSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Product selectedProduct)
        {
            var viewModel = BindingContext as ProductViewModel;
            viewModel.SelectedProduct = selectedProduct;
            viewModel.IsEditing = true;
        }
    }
}

   