using MauiApp3.ModelView;
using SharedLibraryy.Models;
using MauiApp3.Services;

namespace MauiApp3.Pages;

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

    private string GetCount()
    {
        return count.ToString();
    }

    async void AddButtonClicked(object sender, EventArgs e)
    {
        count++;
        // label.Text = GetCount();
    }

    async void DelButtonClicked(object sender, EventArgs e)
    {
        if (count > 1)
            count--;
        // label.Text = GetCount();
    }
}
