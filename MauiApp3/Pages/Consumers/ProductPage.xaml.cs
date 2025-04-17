using MauiApp3.ModelView;
using Newtonsoft.Json;
using MauiApp3.Pages;
using SharedLibraryy.Models;
using MauiApp3.Services;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;




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
            BindingContext = new ProductPageViewModel( selectedCategoryId,  new ProductService(httpClient),
         _cartService,
         navigation);
        }
    
      

    }
}
	
