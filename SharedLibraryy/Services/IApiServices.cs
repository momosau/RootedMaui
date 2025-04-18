
using SharedLibraryy.Models;
using SharedLibraryy.Response;

namespace SharedLibraryy.Services { 
    public interface  IApiServices
    {
        Task<ApiResponse> AddProductAsync(Product product);
        Task<ApiResponse> UpdateProductAsync(Product product);
        Task<ApiResponse> DeleteProductAsync(int id);
        Task<Product> GetProductByIdAsync(int id);
        Task<List<Product>> GetProductsAsync();
        Task<Product?> GetProductWithSpecificationsAsync(int id);

    }

 
}
