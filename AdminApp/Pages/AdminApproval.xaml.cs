using AdminApp.ViewModel;

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
        var applicationId = 1; // Replace with actual application ID
        await _viewModel.ApproveApplicationAsync(applicationId);
    }

    // Reject button click event
    private async void OnRejectButtonClicked(object sender, EventArgs e)
    {
        var applicationId = 1; // Replace with actual application ID
        await _viewModel.ApproveApplicationAsync(applicationId);
    }
}
