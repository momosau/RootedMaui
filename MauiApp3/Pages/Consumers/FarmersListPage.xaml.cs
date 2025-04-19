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
        var selectedFarmer = e.CurrentSelection.FirstOrDefault() as Farmer;
        if (selectedFarmer == null)
            return;

        await Shell.Current.Navigation.PushAsync(new FarmerDetailPage(selectedFarmer));
    }

}


