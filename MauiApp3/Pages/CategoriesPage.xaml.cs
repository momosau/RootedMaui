using Newtonsoft.Json;
using System.Collections.ObjectModel;
using MauiApp3.Pages;
using MauiApp3.ModelView;
using System.ComponentModel;

namespace MauiApp3.Pages;

public partial class CategoriesPage : ContentPage
{
    private int _selectedCategoryId;

    public int SelectedCategoryId
    {
        get => _selectedCategoryId;
        set
        {
            if (_selectedCategoryId != value)
            {
                _selectedCategoryId = value;
                OnPropertyChanged(nameof(SelectedCategoryId));  
            }
        }
    }

    public CategoriesPage()
    {
        InitializeComponent();
        BindingContext = this; 
    }

    private async void OnCategoryTapped(object sender, TappedEventArgs e)
    {
        if (e.Parameter is int categoryId)
        {
            // Set the SelectedCategoryId when a category is tapped
            SelectedCategoryId = categoryId;

            // Navigate to the ProductPage
            await Navigation.PushAsync(new ProductPage(categoryId, Navigation));
        }
    }



    private readonly HttpClient _httpClient = new HttpClient();
    private const string ApiUrl = "https://localhost:7168/api/Categories"; 

    public ObservableCollection<Categooo> Categories { get; set; } = new ObservableCollection<Categooo>();


    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await LoadCategories();
    }

    private async Task LoadCategories()
    {
        try
        {
            var response = await _httpClient.GetStringAsync(ApiUrl);
            var categories = JsonConvert.DeserializeObject<List<Categooo>>(response);

            if (categories != null)
            {
                Categories.Clear();
                foreach (var category in categories)
                {
                    Categories.Add(category);
                }
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("ÎØÃ", "ÝÔá Ýí ÊÍãíá ÇáÈíÇäÇÊ: " + ex.Message, "ãæÇÝÞ");
        }

    }
   
}




public class Categooo
    {
        public int categoryId { get; set; }
        public string categoryName { get; set; }
        public string imagesURL { get; set; }
    }

