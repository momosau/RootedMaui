using MauiApp3.ModelView;
using SharedLibraryy.Models;
using Microsoft.Maui.Controls;

namespace MauiApp3.Pages.Consumers;

public partial class FarmerDetailPage : ContentPage
{
    public Farmer Farmer { get; set; }

    public FarmerDetailPage(Farmer selectedFarmer)
    {
        InitializeComponent();

        Farmer = selectedFarmer;

        var view6 = new FarmerDetailViewModel(selectedFarmer);
        view6.Farmer = selectedFarmer;
        BindingContext = view6;
    }
}
