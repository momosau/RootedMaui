using MauiApp3.ModelView;
using Microsoft.Maui.Controls;
using SharedLibraryy.Models;

namespace MauiApp3.Pages.Consumers;

public partial class FarmersListPage : ContentPage
{
    public FarmersListPage()
    {
        InitializeComponent();
        BindingContext = new FarmersViewModel();
    }

    private async void OnFarmerSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Farmer selectedFarmer)
        {
            await Shell.Current.GoToAsync("PaFarmerDetailPage", new Dictionary<string, object>
            {
                ["SelectedFarmer"] = selectedFarmer
            });
        }

      ((CollectionView)sender).SelectedItem = null;
    }
}
    
