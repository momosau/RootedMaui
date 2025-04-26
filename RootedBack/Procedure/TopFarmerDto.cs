using SharedLibraryy.Models;
using System.ComponentModel.DataAnnotations;

public class TopFarmerDto
{
    [Key]
    public int FarmerId { get; set; }
    public string Name { get; set; }
    public string City { get; set; }
    public string FarmName { get; set; }
   
    public string Email { get; set; }
    public string ImageUrl { get; set; }
    public decimal AvgRating { get; set; }


}

