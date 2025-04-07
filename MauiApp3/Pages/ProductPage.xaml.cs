using MauiApp3.ModelView;
using Newtonsoft.Json;
using MauiApp3.Pages;
using SharedLibraryy.Models;
using MauiApp3.Services;




namespace MauiApp3.Pages
{

    public partial class ProductPage : ContentPage
    {
        public ProductPage(int selectedCategoryId, INavigation navigation)
        {
            InitializeComponent();
            var httpClient = new HttpClient(); 
            BindingContext = new ProductPageViewModel(selectedCategoryId, new ProductService(httpClient), navigation);
        }
    }
}
	
