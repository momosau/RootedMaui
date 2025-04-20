using Microsoft.AspNetCore.Mvc;
using SharedLibraryy.Models;
using SharedLibraryy.Response;
using SharedLibraryy.Services;

namespace RootedBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly IApiServices apiServices;
        private readonly ICategoryService categoryService;
        public ProductsController(IApiServices apiServices, ICategoryService categoryService)
        {
            this.apiServices = apiServices;
            this.categoryService = categoryService;
        }
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProductsAsync() => Ok(await apiServices.GetProductsAsync());
        [HttpGet("{id:int}", Name = "GetProductById")]
        public async Task<ActionResult<Product>> GetProductByIdAsync(int id)
        {
            var product = await apiServices.GetProductWithSpecificationsAsync(id);
            if (product is null)
                return NotFound("Product not found");

            return Ok(product);
        }

        [HttpGet("WithSpec/{id}")]
        public async Task<ActionResult<Product>> GetProductWithSpecifications(int id)
        {
            var product = await apiServices.GetProductWithSpecificationsAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product); // Returns the full product including specifications
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ApiResponse>> DeleteProductAsync(int id)
        {
            var product = await apiServices.GetProductByIdAsync(id);
            if (product is null)
                return NotFound("product not found");

            var response = await apiServices.DeleteProductAsync(product.ProductId);
            return Ok(response);
        }
        [HttpPut]
        public async Task<ActionResult<Product>> UpdateProductAsync(Product product)
        {
            var result = await apiServices.GetProductByIdAsync(product.ProductId);
            if (result is null)
                return NotFound("Product not found");

            var response = await apiServices.UpdateProductAsync(product);
            if (!response.Success)
                return BadRequest(response.Message);  // Handle the failure case

            return Ok(await apiServices.GetProductByIdAsync(product.ProductId));  // Return updated product
        }
        [HttpPost]
        public async Task<ActionResult<ApiResponse>> AddProduct(Product product)
        {
            var response = await apiServices.AddProductAsync(product);

            if (response.Success)
            {
                var newProductId = (int)response.Data; // Get the new product ID from the response
                return CreatedAtAction("GetProductById", new { id = newProductId }, response);
                // Correct the route parameters
            }

            if (!response.Success && response.Message.Contains("Product already exists"))
            {
                return Conflict(response.Message);  // 409 Conflict
            }

            return BadRequest(response.Message);  // 400 Bad Request
        }



        [HttpGet("Categories")]
        
        public async Task<List<Category>> GetCategoriesAsync() => await categoryService.GetCategoriesAsync();

        [HttpGet("farmer/{farmerId}")]
        public async Task<IActionResult> GetProductsByFarmer(int farmerId)
        {
            var products = await apiServices.GetProductsByFarmerAsync(farmerId);

            if (products == null || !products.Any())
                return NotFound("No products found for this farmer");

            return Ok(products);
        }


    }
}

