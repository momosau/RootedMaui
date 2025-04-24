using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SharedLibraryy.Models;

[Table("Questions")]
public partial class Question
{
    [Key]
    [Column("QuestionID")]
    public int QuestionId { get; set; }

    [Column("FarmerID")]
    public int? FarmerId { get; set; }

    [Column("ConsumerID")]
    public int? ConsumerId { get; set; }

    [Column("Question")]
    [StringLength(250)]
    public string Question1 { get; set; } = null!;

    [StringLength(250)]
    public string Email { get; set; } = null!;

    [NotMapped]
    public string Sender =>
    FarmerId.HasValue ? $"مزارع #{FarmerId}" :
    ConsumerId.HasValue ? $"مستهلك #{ConsumerId}" :
    "غير معروف";

}
