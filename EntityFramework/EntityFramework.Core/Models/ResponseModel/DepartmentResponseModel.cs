using System.ComponentModel.DataAnnotations;

namespace EntityFramework.Core.Models.ResponseModel;

public class DepartmentResponseModel
{
    public int Id { get; set; }
    public string? DepartmentName { get; set; }
    public string? Location { get; set; }
}