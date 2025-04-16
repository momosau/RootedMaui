using SharedLibraryy.Models;

namespace MauiApp3.Pages;

[QueryProperty(nameof(SelectedFarmer), "SelectedFarmer")]
public partial class FarmerDetailPage : ContentPage
{
    public FarmerDetailPage()
    {
        InitializeComponent();
    }

    private Farmer _selectedFarmer;
    public Farmer SelectedFarmer
    {
        get => _selectedFarmer;
        set
        {
            _selectedFarmer = value;
            BindingContext = value;
        }
    }
}
