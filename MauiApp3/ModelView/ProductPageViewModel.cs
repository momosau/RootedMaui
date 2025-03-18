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

namespace MauiApp3.ModelView
{
    public partial class ProductPageViewModel : BaseViewModel
    {
        private readonly IProductService productService;
        public ObservableCollection<Product> Products { get; set; } = new();

        public ProductPageViewModel(IProductService productService)
        {
          
            this.productService = productService;
            Title= "المنتجات";
            GetProduct();

        }

        private async void GetProduct()
        {
            var products = await productService.GetProductAsync();
            if (products is null)
                return;
            if (products.Count > 0)
                Products.Clear();
            foreach (var product in products) {
                
                var NewProduct = new Product();
                if (product.ImageUrl != null)
                {
                    var img = Convert.FromBase64String(product.ImageUrl);
                    MemoryStream ms = new MemoryStream(img);
                    //  NewProduct.ImageUrl = ImageSource.FromStream(() => ms);  note check how are you going to save it in the databse if it as base64 cretea tempproduct anf have image typr as imagesource

                }
                NewProduct.ProductId = product.ProductId;
                NewProduct.Name = product.Name;
                NewProduct.Description = product.Description;
                NewProduct.Price = product.Price;
                NewProduct.Reviews = product.Reviews;
                NewProduct.FarmerId = product.FarmerId;
                NewProduct.CategoryId = product.CategoryId;
                NewProduct.Quantity = product.Quantity;
                NewProduct.Weight = product.Weight;
                products.Add(NewProduct);

            } 

           


        }
    }
}




