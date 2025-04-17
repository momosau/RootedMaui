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

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Product>> GetProductByIdAsync(int id)
        {
            var products = await apiServices.GetProductByIdAsync(id);
            if (products is null)
                return NotFound("Product not found");
            else
                return Ok(products);
        }
        [HttpGet("WithSpec/{id:int}")]
        public async Task<ActionResult<Product>> GetProductWithSpec(int id)
        {
            var product = await apiServices.GetProductWithSpecificationsAsync(id);
            if (product is null)
                return NotFound("Product not found");

            return Ok(product);
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
        public async Task<ActionResult<ApiResponse>> UpdateProductAsync(Product product)
        {
            var result = await apiServices.GetProductByIdAsync(product.ProductId);
            if (result is null)
                return NotFound("product not found");

            var response = await apiServices.UpdateProductAsync(product);
            return Ok(response);
        }
        [HttpPost]
    
        public async Task<ActionResult<ApiResponse>> AddProduct(Product product)
        {
            var response = await apiServices.AddProductAsync(product);
            if (response.Success)
            {
                return CreatedAtAction(nameof(GetProductByIdAsync), new { id = product.ProductId }, response);
            }
            return BadRequest(response);
        }


        [HttpGet("Categories")]
        public async Task<ActionResult<List<Category>>> GetCategoriesAsync() => Ok(await categoryService.GetCategoriesAsync());

    }
}
