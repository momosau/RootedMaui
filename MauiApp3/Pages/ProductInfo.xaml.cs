using MauiApp3.ModelView;
using SharedLibraryy.Models;

namespace MauiApp3.Pages;

public partial class ProductInfo : ContentPage
{
    public ProductInfo(Product selectedProduct)
    {
        InitializeComponent();
        BindingContext = new ProductInfoVIewModel(selectedProduct);
    }
   
    public int count = 1;

    private string GetCount()
    {
        return count.ToString();
    }

    async void AddButtonClicked(object sender, EventArgs e)
    {
        count++;
       // label.Text = GetCount();
    }

    async void DelButtonClicked(object sender, EventArgs e)
    {
        if(count>1)
        count--;
       // label.Text = GetCount();
    }
}
