using System.ComponentModel.DataAnnotations;

namespace EntityFramework.Core.Models.RequestModel;

public class DepartmentRequestModel
{
    [Required(ErrorMessage = "Please Enter Department Name: ")]
    [MaxLength(50)]
    public string? DepartmentName { get; set; }
    public string? Location { get; set; }
}