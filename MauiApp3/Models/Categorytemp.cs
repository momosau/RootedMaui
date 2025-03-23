using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp3.Models
{
    public class Categorytemp
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; } = null!;

        public string? ImagesUrl;
    }
}
