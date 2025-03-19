using SharedLibraryy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp3.Services
{
    public interface IProductService
    {
       Task<List<Category>> GetCategoriesAsync();
        Task<List<Product>> GetProductAsync();
    }
}
