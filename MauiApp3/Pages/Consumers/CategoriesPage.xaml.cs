using MauiApp3.ModelView;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace MauiApp3.Pages.Consumers;

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
            SelectedCategoryId = categoryId;
           
            await Navigation.PushAsync(new ProductPage(categoryId, Navigation));
        }
    }

    private readonly HttpClient _httpClient = new HttpClient();
    private readonly string ApiUrl = DeviceInfo.Platform == DevicePlatform.Android
        ? "http://10.0.2.2:5140"
        : "https://localhost:7168";

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
            var response = await _httpClient.GetStringAsync($"{ApiUrl}/api/Categories");
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
            await DisplayAlert("Error", "Failed to load categories: " + ex.Message, "OK");
        }
    }
 
}




public class Categooo
{
    public int categoryId { get; set; }
    public string categoryName { get; set; }
    public string imagesURL { get; set; }
}






