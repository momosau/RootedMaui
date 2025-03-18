using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibraryy.Models
{
    [Table("Category")]
    public partial class Category
    {
        [Key]
        public int CategoryID { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public List<Product> Products { get; set; } = new();

    }
}
