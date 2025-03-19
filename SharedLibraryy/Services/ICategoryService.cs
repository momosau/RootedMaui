using SharedLibraryy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibraryy.Services { 
    public interface ICategoryService
    {
    Task<List<Category>>GetCategoriesAsync();
}
}
