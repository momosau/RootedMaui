using MauiApp3.ModelView;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace MauiApp3.Pages
{

    public partial class ProductPage : ContentPage
    {
        public ProductPage(ProductPageViewModel productPageViewModel)
        {
            InitializeComponent();
            BindingContext = productPageViewModel;
        }

    }
}
	
