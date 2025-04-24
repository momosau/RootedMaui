using AdminApp.ViewModel;
using SharedLibraryy.Models;

namespace AdminApp.Pages;

public partial class AdminApproval : ContentPage
{
    private readonly AdminApprovalViewModel _viewModel;

    public AdminApproval(AdminApprovalViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }

    // Fetch and display pending applications
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _viewModel.LoadPendingApplicationsAsync();
        // Populate UI with the pending applications (e.g., in a ListView or CollectionView)
    }

    // Approve button click event
    private async void OnApproveButtonClicked(object sender, EventArgs e)
    {
        if (sender is Button button && button.BindingContext is FarmerApplication app)
        {
            await _viewModel.ApproveApplicationAsync(app.ApplicationId);
            _viewModel.PendingApplications.Remove(app);
        }
    }


    // Reject button click event
    private async void OnRejectButtonClicked(object sender, EventArgs e)
    {
        if (sender is Button button && button.BindingContext is FarmerApplication app)
        {
            await _viewModel.RejectApplicationAsync(app.ApplicationId);
            _viewModel.PendingApplications.Remove(app);
        }
    }
    private async void OnMoreInfoClicked(object sender, EventArgs e)
    {
        if (sender is Button button && button.BindingContext is FarmerApplication app)
        {

             await Navigation.PushAsync(new FarmerInfo(app));
        }
    }

}
