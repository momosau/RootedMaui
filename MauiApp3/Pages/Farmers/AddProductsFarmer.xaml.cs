using MauiApp3.ModelView;
using SharedLibraryy.Models;

namespace MauiApp3.Pages.Farmers
{
    [QueryProperty(nameof(Product), nameof(Product))]
    public partial class AddProductsFarmer : ContentPage
    {
        private readonly AddProductViewModel _viewModel = new();

        public AddProductsFarmer()
        {
            InitializeComponent();
            BindingContext = _viewModel;
        }

        public Product Product
        {
            set => _viewModel.SetProduct(value);
        }
    }


}
