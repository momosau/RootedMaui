using Newtonsoft.Json;
using SharedLibraryy.Models;
using System.Net.Http.Json;
using System.Text;
using MauiApp3.Helpers;
namespace MauiApp3.Pages.Farmers;

public partial class AddProductPage : ContentPage
{
    private readonly HttpClient _httpClient = new();
    private FileResult? _pickedImage;
    private readonly string ApiUrl = DeviceInfo.Platform == DevicePlatform.Android
     ? "http://10.0.2.2:5140/"
     : "https://localhost:7168/";

    public AddProductPage()
    {
        InitializeComponent();
        LoadDropdowns();
    }

    private async void LoadDropdowns()
    {
        var categories = await _httpClient.GetFromJsonAsync<List<Category>>($"{ApiUrl}api/categories");
        CategoryPicker.ItemsSource = categories;
        CategoryPicker.ItemDisplayBinding = new Binding("CategoryName");

        // Set Farmer Name
        if (UserSession.LoggedInFarmer != null)
        {
            FarmerNameEntry.Text = UserSession.LoggedInFarmer.Name;
        }
    }

    private async void OnPickImageClicked(object sender, EventArgs e)
    {
        _pickedImage = await MediaPicker.PickPhotoAsync();

        if (_pickedImage != null)
        {
            var stream = await _pickedImage.OpenReadAsync();
            SelectedImage.Source = ImageSource.FromStream(() => stream);
        }
    }

    private async void OnAddProductClicked(object sender, EventArgs e)
    {
        var specification = new Specification
        {
            IsOrganic = IsOrganicCheckbox.IsChecked,
            IsGmofree = IsGmofreeCheckbox.IsChecked,
            IsHydroponicallyGrown = IsHydroponicallyGrownCheckbox.IsChecked,
            IsPesticideFree = IsPesticideFreeCheckbox.IsChecked,
            IsLocal = IsLocalCheckbox.IsChecked,
            FarmerId = UserSession.LoggedInFarmer?.FarmerId
        };

       
        typeof(Specification).GetProperty("SpecificationId")?.SetValue(specification, null);

        var product = new Product
        {
            Name = NameEntry.Text,
            Category = (CategoryPicker.SelectedItem as Category)?.CategoryName ?? "CategoryName",
            Price = double.TryParse(PriceEntry.Text, out var price) ? price : 0,
            Quantity = int.TryParse(QuantityEntry.Text, out var qty) ? qty : 0,
            Weight = double.TryParse(WeightEntry.Text, out var weight) ? weight : 0,
            Unit = UnitEntry.Text,
           FarmerId = UserSession.LoggedInFarmer?.FarmerId ?? 1,
            CategoryId = (CategoryPicker.SelectedItem as Category)?.CategoryId ?? 0,
            ImageUrl = _pickedImage != null ? await UploadImageToServer(_pickedImage) : "No Image",
            Description = DescriptionEditor.Text,
            Specification = specification
        };


        var json = JsonConvert.SerializeObject(product);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync($"{ApiUrl}api/products", content);

        if (response.IsSuccessStatusCode)
        {
            await DisplayAlert("Success", "Product added!", "OK");
            await Shell.Current.GoToAsync(".."); // Go back
        }
        else
        {
            await DisplayAlert("Error", "Failed to add product.", "OK");
        }
    }

    private async Task<string> UploadImageToServer(FileResult pickedImage)
    {
        if (pickedImage == null)
            return string.Empty;

        using var stream = await pickedImage.OpenReadAsync();
        var content = new MultipartFormDataContent();
        content.Add(new StreamContent(stream), "file", pickedImage.FileName);

        var response = await _httpClient.PostAsync($"{ApiUrl}api/upload/image", content);

        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<dynamic>(json);
            return result!.imageUrl;
        }

        return string.Empty;
    }


    private bool ValidateInputs(out double price, out double weight, out int quantity)
    {
        price = 0;
        weight = 0;
        quantity = 0;

        if (!double.TryParse(PriceEntry.Text, out price) || price < 0)
        {
            DisplayAlert("Validation", "Price must be a valid positive number.", "OK");
            return false;
        }

        if (!double.TryParse(WeightEntry.Text, out weight) || weight < 0)
        {
            DisplayAlert("Validation", "Weight must be a valid positive number.", "OK");
            return false;
        }

        if (!int.TryParse(QuantityEntry.Text, out quantity) || quantity < 0)
        {
            DisplayAlert("Validation", "Quantity must be a valid positive number.", "OK");
            return false;
        }

        return true;
    }
}