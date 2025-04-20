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
            if (product == null) { return new ApiResponse() { Success = false, Message = "Product is null." }; }

            var check = await _context.Products
                .Where(p => p.Name.ToLower().Equals(product.Name.ToLower()) && p.FarmerId == product.FarmerId)
                .FirstOrDefaultAsync();

            if (check == null)
            {
                if (product.Specification != null)
                {
                    _context.Specifications.Add(product.Specification); // Add Specification if it's part of the product
                }

                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                return new ApiResponse() { Success = true, Message = "Product added successfully." };
            }
            return new ApiResponse() { Success = false, Message = "Product already exists for this farmer." };
        }


        public async Task<ApiResponse> DeleteProductAsync(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.ProductId == id);
            if (product is null)
                return new ApiResponse() { Success = false, Message = "Product is not found." };

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return new ApiResponse() { Success = true, Message = "Product deleted successfully." };
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.ProductId == id);
            return product;
        }

        public async Task<List<Product>> GetProductsAsync() => await _context.Products.ToListAsync();

        public async Task<ApiResponse> UpdateProductAsync(Product product)
        {
            var result = await _context.Products.FirstOrDefaultAsync(p => p.ProductId == product.ProductId);
            if (result is null)
                return new ApiResponse() { Success = false, Message = "Product is not found." };
            //if it did not work try result.Name = product.Name; result.Price = product.Price; result.Quantity = product.Quantity; result.Description = product.Description;
            _context.Update(product);
            await _context.SaveChangesAsync();
            return new ApiResponse() { Success = true, Message = "Product updated successfully." };
        }
        public async Task<Product> GetProductWithSpecificationsAsync(int id)
        {
            var product = await _context.Products
                .Include(p => p.Specification) // Ensure specs are included
                .FirstOrDefaultAsync(p => p.ProductId == id);

            return product; // Returns product with specs
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
