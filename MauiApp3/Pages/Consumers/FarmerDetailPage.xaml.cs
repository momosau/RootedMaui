using SharedLibraryy.Models;
using MauiApp3.ModelView;
using MauiApp3.Services;

namespace MauiApp3.Pages.Consumers;

public partial class FarmerDetailPage : ContentPage
{
    public Farmer Farmer { get; set; }
    private readonly IProductService _productService;

    public FarmerDetailPage(Farmer selectedFarmer)
    {
        InitializeComponent();

        // Initialize HttpClient
        HttpClient httpClient = new HttpClient();

        // Initialize the IProductService with the HttpClient
        _productService = new ProductService(httpClient); // Make sure to use ProductService

        // Initialize ViewModel with the service and the selected farmer
        var viewModel = new FarmerDetailViewModel(_productService, selectedFarmer);

        // Set the BindingContext for the page
        BindingContext = viewModel;
    }
}
