using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp3.Models
{
   public class Productemp
    {
        public int ProductId { get; set; }
        public string Name { get; set; } = null!;
        public double Weight { get; set; }
        public int CategoryId { get; set; }

        public int Quantity { get; set; }
        public string? Description { get; set; }
        public ImageSource ImageUrl { get; set; }
        public int FarmerId { get; set; }


        public double Price { get; set; }
    }
}
