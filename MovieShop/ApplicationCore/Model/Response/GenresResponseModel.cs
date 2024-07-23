using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Model.Response;

public class GenresResponseModel
{
    public int Id { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(24)")]
    public string Name { get; set; }
}