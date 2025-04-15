using SharedLibraryy.Models;

namespace AdminApp.Services
{
    public interface IFarmerApplicationService
    {

        Task<IEnumerable<FarmerApplication>> GetApplicationsAsync(bool? isVerified = null);
        Task<FarmerApplication> GetApplicationByIdAsync(int id);
        Task ApproveApplicationAsync(int id);
        Task RejectApplicationAsync(int id);
    }
}

