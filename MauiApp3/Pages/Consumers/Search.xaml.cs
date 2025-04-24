using MauiApp3.ModelView;
using MauiApp3.Services;
using Newtonsoft.Json;
using SharedLibraryy.Models;
using System.Collections.ObjectModel;

namespace MauiApp3.Pages.Consumers;

public partial class Search : ContentPage
{
    private readonly HttpClient _httpClient = new HttpClient();
    private readonly string ApiUrl = DeviceInfo.Platform == DevicePlatform.Android
        ? "http://10.0.2.2:5140"
        : "https://localhost:7168";

    private ObservableCollection<ProductModel> _searchResults = new ObservableCollection<ProductModel>();

    public Search()
    {
        InitializeComponent();
        SearchResultsCollectionView.ItemsSource = _searchResults;
    }
    private async void OnProductSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count == 0)
            return;

        var selectedProduct = e.CurrentSelection.FirstOrDefault() as ProductModel;
        if (selectedProduct == null)
            return;


        SearchResultsCollectionView.SelectedItem = null;

        // Converting the temporary model to the actual Product Model used
        var product = new Product
        {
            ProductId = selectedProduct.productId,
            Name = selectedProduct.Name,
            ImageUrl = selectedProduct.imageUrl,
            Price = selectedProduct.price,
            Unit = selectedProduct.Unit,
            Weight=selectedProduct.Weight,
            Quantity=selectedProduct.Quantity,
            FarmerId = selectedProduct.FarmerId,
            Farmer = selectedProduct.Farmer};

        // open the product info for that selected searched item
        await Navigation.PushAsync(new ProductInfo(product, new ProductService(_httpClient)));
    }

    private async void OnSearchTextChanged(object sender, TextChangedEventArgs e)
    {
        string query = e.NewTextValue?.Trim();
        if (string.IsNullOrEmpty(query))
        {
            _searchResults.Clear();
            return;
        } try
        {
            var response = await _httpClient.GetStringAsync($"{ApiUrl}/api/Products/search?query={query}");
            var products = JsonConvert.DeserializeObject<List<ProductModel>>(response);

            _searchResults.Clear();
            foreach (var product in products)
            {
                _searchResults.Add(product);
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("خطأ", "فشل في جلب البيانات: " + ex.Message, "موافق");
        }
    }
}

public class ProductModel
{
    public int productId { get; set; }
    public string Name { get; set; }

    public string imageUrl { get; set; }
    public double price { get; set; }
    public double Weight { get; set; }
    public int Quantity { get; set; }
    public int FarmerId { get; set; }
    public Farmer? Farmer { get; set; }  // Make it nullable
    public string Unit { get; set; } = null!;

}