using CommunityToolkit.Mvvm.ComponentModel;
using MauiApp3.Services;
using SharedLibraryy.Models;
using System.Text.Json;
using System.Windows.Input;

namespace MauiApp3.ModelView
{
    public partial class AddProductViewModel : ObservableObject
    {
        private readonly ProductService1 _productService;

        [ObservableProperty]
        private Product newProduct;

        public ICommand SaveProductCommand { get; }
        public ICommand PickImageCommand { get; }

        public AddProductViewModel()
        {
            _productService = new ProductService1();
            NewProduct = new Product
            {
                Specification = new Specification() // Make sure Specification is initialized
            };

            SaveProductCommand = new Command(async () => await SaveProduct());
            //PickImageCommand = new Command(async () => await PickImage());
        }

        public void SetProduct(Product product)
        {
            // In edit mode
            NewProduct = product;

            // Initialize specification if null
            if (NewProduct.Specification == null)
                NewProduct.Specification = new Specification();
        }
        //private async Task PickImage()
        //{
        //    var result = await FilePicker.PickAsync();
        //    if (result != null)
        //    {
        //        // Assuming the result is a valid image path, you can now upload it to cloud storage.
        //        // Example using base64 (you can upload it to a server if needed):
        //        string base64Image = Convert.ToBase64String(await File.ReadAllBytesAsync(result.FullPath));
        //        NewProduct.ImageUrl = base64Image;  // Or save the image URL after uploading it to cloud storage

        //        OnPropertyChanged(nameof(NewProduct)); // Notify UI of the change
        //    }
        //}

        private async Task SaveProduct()
        {
            // Validate form fields
            if (string.IsNullOrWhiteSpace(NewProduct.Name) ||
                NewProduct.Weight <= 0 ||
                string.IsNullOrWhiteSpace(NewProduct.Category) ||
                NewProduct.Quantity <= 0 ||
                NewProduct.Price <= 0 ||
                string.IsNullOrWhiteSpace(NewProduct.Unit) ||
                NewProduct.FarmerId <= 0 ||
                NewProduct.CategoryId <= 0)
            {
                await Application.Current.MainPage.DisplayAlert("خطأ", "يرجى تعبئة جميع الحقول المطلوبة بشكل صحيح.", "موافق");
                return;
            }
            if (string.IsNullOrWhiteSpace(NewProduct.ImageUrl))
            {
                // Set a default image or handle this case appropriately
                NewProduct.ImageUrl = "defaultImage.jpg"; // Example: Set a default image path if no image is provided
            }


            // Serialize product to JSON
            var json = JsonSerializer.Serialize(NewProduct);
            System.Diagnostics.Debug.WriteLine(json); // Debug: Check JSON structure

            // Call the product service to save the product
            if (NewProduct.ProductId == 0)
            {
                await _productService.AddProduct(NewProduct);
            }
            else
            {
                await _productService.UpdateProduct(NewProduct);
            }

            // Navigate back after saving
            await Shell.Current.GoToAsync("..");
        }

    }
}
