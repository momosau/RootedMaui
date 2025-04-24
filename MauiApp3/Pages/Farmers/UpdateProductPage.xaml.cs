using Newtonsoft.Json;
using SharedLibraryy.Models;
using System.Net.Http.Json;
using System.Text;

namespace MauiApp3.Pages.Farmers
{
    [QueryProperty(nameof(ProductId), "productId")]
    public partial class UpdateProductPage : ContentPage
    {
        public int ProductId { get; set; }

        private readonly HttpClient _httpClient = new();
        private Product _product = new();
        private FileResult? _pickedImage;
        private readonly string ApiUrl = DeviceInfo.Platform == DevicePlatform.Android
? "http://10.0.2.2:5140/"
: "https://localhost:7168/";
        public UpdateProductPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await LoadProductAsync(ProductId);
        }

        private async Task LoadDropdowns()
        {
            var categories = await _httpClient.GetFromJsonAsync<List<Category>>($"{ApiUrl}api/categories");
            CategoryPicker.ItemsSource = categories;
            CategoryPicker.ItemDisplayBinding = new Binding("CategoryName");

            var farmers = await _httpClient.GetFromJsonAsync<List<Farmer>>($"{ApiUrl}api/farmers");
            FarmerPicker.ItemsSource = farmers;
            FarmerPicker.ItemDisplayBinding = new Binding("Name");
        }

        private async Task LoadProductAsync(int id)
        {
            try
            {
                var json = await _httpClient.GetStringAsync($"{ApiUrl}api/products/{id}");
                _product = JsonConvert.DeserializeObject<Product>(json)!;

                // Load dropdowns first so ItemsSource is ready before setting SelectedItem
                await LoadDropdowns();

                // Bind data to UI
                NameEntry.Text = _product.Name;
                PriceEntry.Text = _product.Price.ToString();
                QuantityEntry.Text = _product.Quantity.ToString();
                WeightEntry.Text = _product.Weight.ToString();
                UnitEntry.Text = _product.Unit;
                DescriptionEditor.Text = _product.Description;

                // Set checkboxes
                IsOrganicCheckbox.IsChecked = _product.Specification?.IsOrganic ?? false;
                IsGmofreeCheckbox.IsChecked = _product.Specification?.IsGmofree ?? false;
                IsHydroponicallyGrownCheckbox.IsChecked = _product.Specification?.IsHydroponicallyGrown ?? false;
                IsPesticideFreeCheckbox.IsChecked = _product.Specification?.IsPesticideFree ?? false;
                IsLocalCheckbox.IsChecked = _product.Specification?.IsLocal ?? false;

                // Now that ItemsSource is loaded, we can safely set SelectedItem
                CategoryPicker.SelectedItem = CategoryPicker.ItemsSource?.Cast<Category>().FirstOrDefault(c => c.CategoryId == _product.CategoryId);
                FarmerPicker.SelectedItem = FarmerPicker.ItemsSource?.Cast<Farmer>().FirstOrDefault(f => f.FarmerId == _product.FarmerId);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Failed to load product: {ex.Message}", "OK");
            }
        }


        private async void OnUpdateProductClicked(object sender, EventArgs e)
        {
            if (!ValidateInputs(out double price, out double weight, out int quantity)) return;

            _product.Name = NameEntry.Text;
            _product.Category = (CategoryPicker.SelectedItem as Category)?.CategoryName ?? _product.Category;
            _product.Price = price;
            _product.Quantity = quantity;
            _product.Weight = weight;
            _product.Unit = UnitEntry.Text;
            _product.Description = DescriptionEditor.Text;
            _product.CategoryId = (CategoryPicker.SelectedItem as Category)?.CategoryId ?? _product.CategoryId;
            _product.FarmerId = (FarmerPicker.SelectedItem as Farmer)?.FarmerId ?? _product.FarmerId;

            _product.Specification ??= new Specification();
            _product.Specification.IsOrganic = IsOrganicCheckbox.IsChecked;
            _product.Specification.IsGmofree = IsGmofreeCheckbox.IsChecked;
            _product.Specification.IsHydroponicallyGrown = IsHydroponicallyGrownCheckbox.IsChecked;
            _product.Specification.IsPesticideFree = IsPesticideFreeCheckbox.IsChecked;
            _product.Specification.IsLocal = IsLocalCheckbox.IsChecked;

            var json = JsonConvert.SerializeObject(_product);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"https://localhost:7168/api/products/{_product.ProductId}", content);

            if (response.IsSuccessStatusCode)
            {
                await DisplayAlert("Updated", "Product updated successfully!", "OK");
                await Shell.Current.GoToAsync("..");
            }
            else
            {
                await DisplayAlert("Error", "Failed to update product.", "OK");
            }
        }

        private bool ValidateInputs(out double price, out double weight, out int quantity)
        {
            price = 0;
            weight = 0;
            quantity = 0;

            bool isValid = true;

            if (!double.TryParse(PriceEntry.Text, out price))
            {
                DisplayAlert("Error", "Invalid price.", "OK");
                isValid = false;
            }

            if (!double.TryParse(WeightEntry.Text, out weight))
            {
                DisplayAlert("Error", "Invalid weight.", "OK");
                isValid = false;
            }

            if (!int.TryParse(QuantityEntry.Text, out quantity))
            {
                DisplayAlert("Error", "Invalid quantity.", "OK");
                isValid = false;
            }

            return isValid;
        }
    }
}
