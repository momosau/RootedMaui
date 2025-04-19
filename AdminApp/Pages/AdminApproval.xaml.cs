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
            // You now have access to all info of the clicked FarmerApplication
            string name = app.Name;
            string email = app.Email;
            string description = app.Description;
            string phoneNumber = app.PhoneNumber;
            DateOnly date = app.SubmitDate;
            string farmName = app.FarmName;
            string street = app.Street;
            string city = app.City;
            string neighborhood = app.Neighborhood;
            string userName = app.UserName;
            string certificate = app.Certificate;
            string imageUrl = app.ImageUrl;
            string farmNum = app.FarmNum.ToString();

            // Example: show a pop-up with details
            await DisplayAlert("Farmer Info",
                $"Name: {name}\nEmail: {email}\nDescription: {description}",
                "OK");

            // OR navigate to a details page and pass the object
            // await Navigation.PushAsync(new FarmerDetailPage(app));
        }
    }

}
