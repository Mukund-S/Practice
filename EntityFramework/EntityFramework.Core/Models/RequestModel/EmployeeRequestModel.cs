using System.ComponentModel.DataAnnotations;

namespace EntityFramework.Core.Models.RequestModel;

public class EmployeeRequestModel
{
    [Required(ErrorMessage = "Employee Name is Required")]
    [StringLength(256)]
    public string? EmployeeName{get; set;}
    
    public int Age{get; set;}
    
}