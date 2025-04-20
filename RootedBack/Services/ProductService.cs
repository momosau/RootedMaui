using Microsoft.EntityFrameworkCore;
using RootedBack.Data;
using SharedLibraryy.Models;
using SharedLibraryy.Response;
using SharedLibraryy.Services;

namespace RootedBack.Services
{
    public class ProductService : IApiServices
    {
        private readonly RootedDBContext _context;

        public ProductService(RootedDBContext context)
        {
            _context = context;
        }

        public async Task<ApiResponse> AddProductAsync(Product product)
        {
            if (product == null)
                return new ApiResponse { Success = false, Message = "Product is null." };

            try
            {
                var exists = await _context.Products
                    .FirstOrDefaultAsync(p => p.Name.ToLower() == product.Name.ToLower() && p.FarmerId == product.FarmerId);

                if (exists != null)
                    return new ApiResponse { Success = false, Message = "Product already exists for this farmer." };

                if (product.Specification != null)
                    _context.Specifications.Add(product.Specification);

                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException ex)
                {
                    Console.WriteLine("DbUpdateException: " + ex.Message);

                    if (ex.InnerException != null)
                    {
                        Console.WriteLine("Inner Exception: " + ex.InnerException.Message);
                    }

                    throw; // You can comment this out if you just want to debug
                }


                return new ApiResponse
                {
                    Success = true,
                    Message = "Product added successfully.",
                    Data = product.ProductId // returning new ID
                };
            }
            catch (Exception ex)
            {
                // Log the exception for debugging purposes
                return new ApiResponse { Success = false, Message = $"Error: {ex.Message}" };
            }
        }


        public async Task<ApiResponse> DeleteProductAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
                return new ApiResponse { Success = false, Message = "Product not found." };

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return new ApiResponse { Success = true, Message = "Product deleted successfully." };
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<ApiResponse> UpdateProductAsync(Product product)
        {
            var existing = await _context.Products
                .Include(p => p.Specification)
                .FirstOrDefaultAsync(p => p.ProductId == product.ProductId);

            if (existing == null)
                return new ApiResponse { Success = false, Message = "Product not found." };

            try
            {
                // Update Product fields
                existing.Name = product.Name;
                existing.Description = product.Description;
                existing.Price = product.Price;
                existing.Quantity = product.Quantity;
                existing.CategoryId = product.CategoryId;
                existing.Category = product.Category;
                existing.Unit = product.Unit;
                existing.Weight = product.Weight;
                existing.ImageUrl = product.ImageUrl;

                // Update specification if provided
                if (product.Specification != null)
                {
                    if (existing.Specification == null)
                    {
                        // Link new specification
                        existing.Specification = product.Specification;
                    }
                    else
                    {
                        existing.Specification.IsOrganic = product.Specification.IsOrganic;
                        existing.Specification.IsGmofree = product.Specification.IsGmofree;
                        existing.Specification.IsHydroponicallyGrown = product.Specification.IsHydroponicallyGrown;
                        existing.Specification.IsPesticideFree = product.Specification.IsPesticideFree;
                        existing.Specification.IsLocal = product.Specification.IsLocal;
                    }
                }

                await _context.SaveChangesAsync();
                return new ApiResponse { Success = true, Message = "Product updated successfully." };
            }
            catch (Exception ex)
            {
                return new ApiResponse { Success = false, Message = $"Update failed: {ex.Message}" };
            }
        }

        public async Task<Product> GetProductWithSpecificationsAsync(int id)
        {
            return await _context.Products
                .Include(p => p.Specification)
                .FirstOrDefaultAsync(p => p.ProductId == id);
        }

        public async Task<List<Product>> GetProductsByFarmerAsync(int farmerId)
        {
            return await _context.Products
                .Include(p => p.CategoryNavigation)
                .Where(p => p.FarmerId == farmerId)
                .ToListAsync();
        }
    }
}
