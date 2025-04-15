using MauiApp3.Services;
using SharedLibraryy.Models;
using System.Windows.Input;

namespace MauiApp3.ModelView
{
    public partial class AddProductViewModel : BaseViewModel
    {
        private readonly ProductService1 _productService;
        public Product NewProduct { get; private set; } = new();

        public ICommand SaveProductCommand { get; }
        public ICommand PickImageCommand { get; }
        public AddProductViewModel()
        {
            _productService = new ProductService1();
            SaveProductCommand = new Command(async () => await SaveProduct());
            PickImageCommand = new Command(async () => await PickImage());

            // Initialize specifications
            NewProduct.Specifications.Add(new Specification());
        }
        public void SetProduct(Product product)
        {
            NewProduct = product;
            OnPropertyChanged(nameof(NewProduct));
        }

        private async Task SaveProduct()
        {
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
                NewProduct.ImageUrl = result.FullPath;
        }
    }

}
