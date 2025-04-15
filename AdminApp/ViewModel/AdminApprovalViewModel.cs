using AdminApp.Services;
using SharedLibraryy.Models;
using System.Collections.ObjectModel;

namespace AdminApp.ViewModel
{
    public class AdminApprovalViewModel : BaseViewModel
    {
        private readonly IFarmerApplicationService _farmerApplicationService;

        public ObservableCollection<FarmerApplication> PendingApplications { get; } = new ObservableCollection<FarmerApplication>();

        private bool isLoading;
        public bool IsLoading
        {
            get => isLoading;
            set => SetProperty(ref isLoading, value);
        }


        public AdminApprovalViewModel(IFarmerApplicationService farmerApplicationService)
        {
            _farmerApplicationService = farmerApplicationService;
        }

        // Fetch pending applications
        public async Task LoadPendingApplicationsAsync()
        {
            IsLoading = true;
            var applications = await _farmerApplicationService.GetApplicationsAsync(false); // false = not verified
            PendingApplications.Clear();
            foreach (var app in applications)
            {
                PendingApplications.Add(app);
            }
            IsLoading = false;
        }

        // Approve an application
        public async Task ApproveApplicationAsync(int id)
        {
            await _farmerApplicationService.ApproveApplicationAsync(id);
        }

        // Reject an application
        public async Task RejectApplicationAsync(int id)
        {
            await _farmerApplicationService.RejectApplicationAsync(id);
        }
    }
}
