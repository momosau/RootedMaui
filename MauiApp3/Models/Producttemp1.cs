using SharedLibraryy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp3.Models
{
    internal class Producttemp1
    {
        public int ProductId { get; set; }
        public string? Name { get; set; }
        public double Weight { get; set; }
        public string Category { get; set; }
        public int Quantity { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public string? ImageUrl { get; set; }
        public int FarmerId { get; set; }
        public int CategoryId { get; set; }
        public List<Specification> Specifications { get; set; } = new();
    }
}
