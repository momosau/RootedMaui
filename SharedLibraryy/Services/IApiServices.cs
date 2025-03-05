using Refit;
using SharedLibraryy.Models;

namespace SharedLibraryy.Services
{
    public interface  IApiServices
    {

        Task<List<Admin>> GetAdminsAsync();
        Task<Admin> GetAdminByIdAsync(int id);
        Task<bool> CreateAdminAsync(Admin admin);
    }
}
