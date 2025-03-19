using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using SharedLibraryy.Models;
using Microsoft.Maui.Controls;
using MauiApp3.ModelView;
using MauiApp3.Services;
using MauiApp3.Models;

namespace MauiApp3.ModelView
{
    public partial class ProductPageViewModel : BaseViewModel
    {
        private readonly IProductService productService;
        public ObservableCollection<Productemp> products { get; set; } = new();
        public ObservableCollection<Category> Categories { get; set; } = new();

        public ProductPageViewModel(IProductService productService)
        {
          
            this.productService = productService;
            Title= "المنتجات";
            GetCategories();
            GetProduct();
           

        }
        private async void GetCategories()
        {
            var categories = await productService.GetCategoriesAsync();
            if (categories is null || categories.Count == 0)
                return;
            categories.Clear();
            foreach (var category in categories)
            { var Newcategory = new Category
            { CategoryId = category.CategoryId,
                CategoryName = category.CategoryName

            };
                Categories.Add(Newcategory);
            }
        }

        private async void GetProduct()
        {
            var productList = await productService.GetProductAsync();
            if (productList is null || productList.Count == 0)
                return;

            products.Clear();

            foreach (var product in productList)
            {
                var newProduct = new Productemp
                {
                    ProductId = product.ProductId,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    FarmerId = product.FarmerId,
                    CategoryId = product.CategoryId,
                    Quantity = product.Quantity,
                    Weight = product.Weight
                };

                /* // Convert Base64 image to ImageSource
                 if (!string.IsNullOrEmpty(product.ImageUrl))
                 {
                     var img = Convert.FromBase64String(product.ImageUrl);
                     MemoryStream ms = new MemoryStream(img);
                     newProduct.ImageUrl = ImageSource.FromStream(() => ms);
                 }*/

                // Load image from file path instead of Base64 conversion
                if (!string.IsNullOrEmpty(product.ImageUrl))
                {
                    string imagePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), product.ImageUrl);
                    if (File.Exists(imagePath))
                    {
                        newProduct.ImageUrl = ImageSource.FromFile(imagePath);
                    }
                    else
                    {
                        // Optional: Set a default image if file not found
                        newProduct.ImageUrl = ImageSource.FromFile("Vegetable.png");
                    }
                }

                products.Add(newProduct);
            }
        }





    }
}




