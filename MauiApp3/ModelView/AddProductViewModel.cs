using CommunityToolkit.Mvvm.ComponentModel;
using MauiApp3.Services;
using SharedLibraryy.Models;
using System.Windows.Input;
using System.Threading.Tasks;
using Microsoft.Maui.Storage;

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
            PickImageCommand = new Command(async () => await PickImage());
        }

        public void SetProduct(Product product)
        {
            // In edit mode
            NewProduct = product;

            // Initialize specification if null
            if (NewProduct.Specification == null)
                NewProduct.Specification = new Specification();
        }

        private async Task SaveProduct()
        {
            if (NewProduct == null)
                return;

            if (NewProduct.ProductId == 0)
                await _productService.AddProduct(NewProduct);
            else
                await _productService.UpdateProduct(NewProduct);

            await Shell.Current.GoToAsync("..");
        }

        private async Task PickImage()
        {
            var result = await FilePicker.PickAsync();
            if (result != null)
            {
                NewProduct.ImageUrl = result.FullPath;
                OnPropertyChanged(nameof(NewProduct));
            }
        }
    }
}
