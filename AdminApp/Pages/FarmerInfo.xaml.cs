using AdminApp.ViewModel;
using SharedLibraryy.Models;
namespace AdminApp.Pages;

public partial class FarmerInfo : ContentPage
{
    private readonly AdminApprovalViewModel _viewModel;


    public FarmerInfo(FarmerApplication selectedFarmer)
    {
        InitializeComponent();

        BindingContext = selectedFarmer;
    }
}