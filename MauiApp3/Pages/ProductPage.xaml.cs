
using MauiApp3.ModelView;
using Newtonsoft.Json;
using MauiApp3.Pages;




namespace MauiApp3.Pages
{

    public partial class ProductPage : ContentPage
    {
        public ProductPage(ProductPageViewModel productPageViewModel)
        {
            InitializeComponent();
            BindingContext = productPageViewModel;
        }
         
 
        public async void AddButtonClicked(object sender, EventArgs e)
        {
          
        
            OnPropertyChanged();
        }


        private void OnCategoryChanged(object sender, EventArgs e)
        {
            var picker = sender as Picker;
            if (picker?.SelectedItem is Models.Categorytemp selectedCategory)
            {
                (BindingContext as ProductPageViewModel).SelectedCategory = selectedCategory.CategoryId.ToString();
            }
        }

        private void OnCategorySelected(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.FirstOrDefault() is Models.Categorytemp selectedCategory)
            {
                (BindingContext as ProductPageViewModel).SelectedCategory = selectedCategory.CategoryId.ToString();
            }
        }

    }
}
	
