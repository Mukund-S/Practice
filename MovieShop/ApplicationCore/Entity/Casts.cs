using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entity;

public class Casts
{
    public int Id { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(MAX)")]
    public string Gender { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(128)")]
    public string Name { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(2084)")]
    public string ProfilePath { get; set; }
    [Required]
    [Column(TypeName = "nvarchar(MAX)")]
    public string TmdbUrl { get; set; }
    public ICollection<MovieCasts> MovieCasts { get; set; }
}