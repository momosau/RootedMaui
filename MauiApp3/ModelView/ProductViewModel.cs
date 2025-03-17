using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

using MauiApp3.Pages;
using System.Windows.Input;
using System.ComponentModel;


namespace MauiApp3.ModelView
{

    public partial class ProductViewModel : ObservableObject
    {
        public ObservableCollection<Product> Products { get; set; }
        public Product SelectedProduct { get; set; }
        private bool _isEditing;

        public bool IsEditing
        {
            get => _isEditing;
            set
            {
                _isEditing = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddProductCommand { get; }
        public ICommand EditProductCommand { get; }
        public ICommand DeleteProductCommand { get; }
        public ICommand SaveChangesCommand { get; }
        public ICommand PickImageCommand { get; }

        public ProductViewModel()
        {
            Products = new ObservableCollection<Product>();

            AddProductCommand = new Command(AddProduct);
            EditProductCommand = new Command<Product>(EditProduct);
            DeleteProductCommand = new Command<Product>(DeleteProduct);
            SaveChangesCommand = new Command(SaveChanges);
            PickImageCommand = new Command(async () => await PickImage());
        }

        private void AddProduct()
        {
            var newProduct = new Product { };
            Products.Add(newProduct);
            SelectedProduct = newProduct;
            IsEditing = true;
        }

        private void EditProduct(Product product)
        {
            SelectedProduct = product;
            IsEditing = true;
        }

        private void DeleteProduct(Product product)
        {
            if (product != null)
            {
                Products.Remove(product);
                IsEditing = false;
            }
        }

        private void SaveChanges()
        {
            IsEditing = false;
        }

        private async Task PickImage()
        {
            var result = await FilePicker.PickAsync(new PickOptions
            {
                PickerTitle = "Pick an image",
                FileTypes = FilePickerFileType.Images
            });

            if (result != null && SelectedProduct != null)
            {
                SelectedProduct.Image = result.FullPath;
            }
        }
    }

    
        public class Product : INotifyPropertyChanged
        {
            private string _name;
            private decimal _price;
            private string _image;
            private int _quantity;

            public event PropertyChangedEventHandler PropertyChanged;

            public string Name
            {
                get => _name;
                set { _name = value; OnPropertyChanged(nameof(Name)); }
            }

            public decimal Price
            {
                get => _price;
                set { _price = value; OnPropertyChanged(nameof(Price)); }
            }

            public string Image
            {
                get => _image;
                set { _image = value; OnPropertyChanged(nameof(Image)); }
            }

            public int Quantity
            {
                get => _quantity;
                set { _quantity = value; OnPropertyChanged(nameof(Quantity)); }
            }

            protected void OnPropertyChanged(string propertyName) =>
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    

}