using SharedLibraryy.Models;


namespace SharedLibraryy.Services
{
public interface IFarmerApplicationsService
    {

        Task<List<FarmerApplication>> GetAllAsync();
        Task<List<FarmerApplication>> GetPendingAsync();
        Task<FarmerApplication?> GetByIdAsync(int id);
        Task<FarmerApplication> CreateAsync(FarmerApplication app);
        Task<bool> UpdateAsync(int id, FarmerApplication app);
        Task<bool> DeleteAsync(int id);
        Task<Farmer> AcceptApplicationAsync(int id);
        Task<bool> RejectApplicationAsync(int id);

    }
}
