using MauiApp3.ModelView;
using Newtonsoft.Json;
using MauiApp3.Pages;
using SharedLibraryy.Models;




namespace MauiApp3.Pages
{

    public partial class ProductPage : ContentPage
    {
        public ProductPage(string selectedCategory)
        {
            InitializeComponent();
            BindingContext = new ProductPageViewModel(selectedCategory);
        }

    }
}
	
