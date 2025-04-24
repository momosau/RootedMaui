using Newtonsoft.Json;
using SharedLibraryy.Models;
using System.Diagnostics;

namespace MauiApp3.Pages.Farmers;

public partial class ProductsPage : ContentPage
{
    private readonly HttpClient _httpClient = new();
    private Product _selectedProduct = new();

    public ProductsPage()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(AddProductPage), typeof(AddProductPage));
        Routing.RegisterRoute(nameof(UpdateProductPage), typeof(UpdateProductPage));

        LoadProducts();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        LoadProducts();
    }

    private async void LoadProducts()
    {
        try
        {
            var response = await _httpClient.GetStringAsync("https://localhost:7168/api/products");
            var products = JsonConvert.DeserializeObject<List<Product>>(response);
            ProductsView.ItemsSource = products;
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Failed to load products: {ex.Message}", "OK");
        }
    }

    private void OnProductSelected(object sender, SelectionChangedEventArgs e)
    {
        _selectedProduct = (Product)e.CurrentSelection.FirstOrDefault()!;
    }

    private async void OnAddClicked(object sender, EventArgs e)
    {
        try
        {
            await Shell.Current.GoToAsync("AddProductPage");
        }
        catch (Exception ex)
        {
            // Handle or log the error  
            Debug.WriteLine($"Navigation error: {ex.Message}");
        }
    }

    private async void OnUpdateClicked(object sender, EventArgs e)
    {
        if (_selectedProduct == null) return;
        await Shell.Current.GoToAsync($"UpdateProductPage?productId={_selectedProduct.ProductId}");
    }

    private async void OnDeleteClicked(object sender, EventArgs e)
    {
        if (_selectedProduct == null) return;

        var confirm = await DisplayAlert("Confirm", "Delete this product?", "Yes", "No");
        if (!confirm) return;

        try
        {
            var response = await _httpClient.DeleteAsync($"https://localhost:7168/api/products/{_selectedProduct.ProductId}");
            if (response.IsSuccessStatusCode)
            {
                await DisplayAlert("Deleted", "Product deleted successfully.", "OK");
                LoadProducts();
            }
            else
            {
                await DisplayAlert("Error", "Failed to delete product.", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", ex.Message, "OK");
        }
    }
}