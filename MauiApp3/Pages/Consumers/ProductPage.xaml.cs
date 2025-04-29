using MauiApp3.ModelView;
using Newtonsoft.Json;
using MauiApp3.Pages;
using SharedLibraryy.Models;
using MauiApp3.Services;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.DependencyInjection;




namespace MauiApp3.Pages.Consumers
{

    public partial class ProductPage : ContentPage
    {
        public ICommand AddToCartCommand { get; }
        private readonly ICartService _cartService;  
        public ProductPage(int selectedCategoryId, INavigation navigation)
        {
            InitializeComponent();
            var httpClient = new HttpClient();
            _cartService = new CartService(httpClient);
            this.BindingContext = new ProductPageViewModel(selectedCategoryId, new ProductService(httpClient), _cartService, navigation);

        }
        private async void AddToCartCLicked(object sender, EventArgs e)
        {
            if (BindingContext is ProductPageViewModel vm)
            {
                var cartViewModel = Ioc.Default.GetRequiredService<CartViewModel>();
                // Pass the quantity and selected product to add to the cart
               
                    // Ensure AddToCartCommand is implemented in CartViewModel
                    cartViewModel.AddToCartCommand.Execute(vm.SelectedProduct);
                

                // Update the cart page
                await Navigation.PushAsync(new ShoppingCart(_cartService));
            }
        }



    }
}
	
