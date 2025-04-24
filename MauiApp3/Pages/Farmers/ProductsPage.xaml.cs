using Newtonsoft.Json;
using SharedLibraryy.Models;
using System.Diagnostics;

namespace MauiApp3.Pages.Farmers;

public partial class ProductsPage : ContentPage
{
    private readonly HttpClient _httpClient = new();
    private Product _selectedProduct = new();
    private readonly string ApiUrl = DeviceInfo.Platform == DevicePlatform.Android
? "http://10.0.2.2:5140/"
: "https://localhost:7168/";

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
            var response = await _httpClient.GetStringAsync($"{ApiUrl}api/products");
            var products = JsonConvert.DeserializeObject<List<Product>>(response);
            ProductsView.ItemsSource = products.Where(w => w.FarmerId==2).ToList();
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

        var confirm = await DisplayAlert("تأكيد", "هل تريد حذف المنتج", "نعم", "لا");
        if (!confirm) return;

        try
        {
            var response = await _httpClient.DeleteAsync($"{ApiUrl}api/products/{_selectedProduct.ProductId}");
            if (response.IsSuccessStatusCode)
            {
                await DisplayAlert("تم حذف المنتج", "تم حذف المنتج بنجاح", "حسنا");
                LoadProducts();
            }
            else
            {
                await DisplayAlert("خطأ", "لم يتم حذف المنتج", "حسنا");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("خطأ", ex.Message, "حسنا");
        }
    }
}