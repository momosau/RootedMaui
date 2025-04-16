using MauiApp3.ModelView;
using SharedLibraryy.Models;
using MauiApp3.Services;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.DependencyInjection;

namespace MauiApp3.Pages.Consumers;

public partial class ProductInfo : ContentPage
{
    private readonly IProductService _productService;

    public ProductInfo(Product selectedProduct, IProductService productService)
    {
        InitializeComponent();
        _productService = productService ?? throw new ArgumentNullException(nameof(productService));

        var viewModel = new ProductInfoVIewModel(selectedProduct, _productService);
        BindingContext = viewModel;
    }

    public int count = 1;


    private async void AddToCartCLicked(object sender, EventArgs e)
    {
        if (BindingContext is ProductInfoVIewModel vm)
        {
            var cartViewModel = Ioc.Default.GetRequiredService<CartViewModel>();
            for (int i = 0; i < vm.QuantityInCart; i++)
            {
                cartViewModel.AddToCartCommand.Execute(vm.SelectedProduct);
            }


            await Shell.Current.GoToAsync(nameof(Pages.Consumers.ShoppingCart));
        }
    }


    private void OnIncreaseClicked(object sender, EventArgs e)
    {
        if (BindingContext is ProductInfoVIewModel vm)
            vm.IncreaseQuantity();
    }

    private void OnDecreaseClicked(object sender, EventArgs e)
    {
        if (BindingContext is ProductInfoVIewModel vm)
            vm.DecreaseQuantity();
    }
}
