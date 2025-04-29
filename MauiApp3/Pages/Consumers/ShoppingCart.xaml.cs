using CommunityToolkit.Mvvm.DependencyInjection;
using MauiApp3.ModelView;
using MauiApp3.Services;
using SharedLibraryy.Models;

namespace MauiApp3.Pages.Consumers;

public partial class ShoppingCart : ContentPage
{
    private readonly CartViewModel _cartViewModel;
    private readonly ICartService _cartService;


    public ShoppingCart(ICartService cartService)
    {
        InitializeComponent();

        // Get CartViewModel from Dependency Injection container
        _cartViewModel = Ioc.Default.GetRequiredService<CartViewModel>();

        // Check if _cartViewModel is null
        if (_cartViewModel == null)
        {
            Console.WriteLine("CartViewModel is null");
            // Handle the null case, maybe set a default value or log an error
        }

        BindingContext = _cartViewModel;
    }

    private void OnIncreaseClicked(object sender, EventArgs e)
    {
        if (sender is Button button && button.BindingContext is Cart cartItem)
        {
            cartItem.Quantity += 1;
            (BindingContext as CartViewModel)?.RecalculateTotal();
        }
    }
    private async void NextPageLoc(object sender, EventArgs e)
    {


        await Shell.Current.GoToAsync("MyLocationPage");
    }

    private async void OnDecreaseClicked(object sender, EventArgs e)
    {
        if (sender is Button button && button.BindingContext is Cart cartItem)
        {
            if (cartItem.Quantity > 1)
            {
                // Decrease quantity
                cartItem.Quantity -= 1;
            }
            else
            {
                // Confirm removal
                var confirm = await DisplayAlert("تأكيد", "هل تريد إزالة هذا المنتج من السلة؟", "نعم", "لا");
                if (confirm)
                {
                    // Remove item from Cart
                    _cartViewModel.Cartitem.Remove(cartItem);
                }
            }

            // Recalculate total after the update
            _cartViewModel.RecalculateTotal();
            // Optionally, notify UI explicitly about changes
            OnPropertyChanged(nameof(_cartViewModel.Cartitem)); // Notify UI if needed
        }
    }

}




