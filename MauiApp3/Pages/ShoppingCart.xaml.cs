using CommunityToolkit.Mvvm.DependencyInjection;
using MauiApp3.ModelView;
using MauiApp3.Services;
using SharedLibraryy.Models;
using System.Collections.ObjectModel;

namespace MauiApp3.Pages;

public partial class ShoppingCart : ContentPage
{
    private readonly CartViewModel _cartViewModel;
    private readonly ICartService _cartService;


    public ShoppingCart(ICartService cartService)
    {
        InitializeComponent();

        _cartViewModel = new CartViewModel(cartService);

        BindingContext = Ioc.Default.GetRequiredService<CartViewModel>();
    }
    private void OnIncreaseClicked(object sender, EventArgs e)
    {
        if (sender is Button button && button.BindingContext is Cart cartItem)
        {
            cartItem.Quantity += 1;
            (BindingContext as CartViewModel)?.RecalculateTotal();
        }
    }

    private async void OnDecreaseClicked(object sender, EventArgs e)
    {
            if (sender is Button button && button.BindingContext is Cart cartItem)
            {
                if (cartItem.Quantity > 1)
                {
                    cartItem.Quantity -= 1;
                    (BindingContext as CartViewModel)?.RecalculateTotal();
                }
                else
            {
                var confirm = await DisplayAlert("تأكيد", "هل تريد إزالة هذا المنتج من السلة؟", "نعم", "لا");
                if (confirm)
                {
                    _cartViewModel.Cartitem.Remove(cartItem);
                    _cartViewModel.RecalculateTotal();
                }

            }

        }
    }
}



  