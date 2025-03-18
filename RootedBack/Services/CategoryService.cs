using Microsoft.EntityFrameworkCore;
using RootedBack.Data;
using SharedLibraryy.Models;
using SharedLibraryy.Services;

namespace RootedBack.Services
{
    public class CategoryService: ICategoryService
    {
        private readonly RootedDBContext rootedDBContext;
        public CategoryService(RootedDBContext rootedDbContext)
        {
            this.rootedDBContext   = rootedDbContext;
        }

        public async Task<List<Category>> GetCategoriesAsync()=> await rootedDBContext.Categories.ToListAsync();
    }
}
