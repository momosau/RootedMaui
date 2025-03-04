using Refit;
using SharedLibraryy.Models;

namespace SharedLibraryy.Services
{
    public interface  IApiServices
    {

        Task<List<Product>> GetProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task<bool> CreateProductAsync(Product product);
    }
}
