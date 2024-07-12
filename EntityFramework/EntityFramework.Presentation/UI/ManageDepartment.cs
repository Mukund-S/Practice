using EntityFramework.Core.Entities;
using EntityFramework.Core.Models.RequestModel;
using EntityFramework.Core.Models.ResponseModel;
using EntityFramework.Infrastructure.Repositories;
using EntityFramework.Infrastructure.Services;

namespace EntityFramework.UI;

public class ManageDepartment
{
    // private DepartmentRepository _departmentRepository = new DepartmentRepository();
    private DepartmentService _departmentService = new DepartmentService();

    private void AddDepartment()
    {
        DepartmentRequestModel department = new DepartmentRequestModel();
        Console.WriteLine("Enter Department Name =>");
        department.DepartmentName = Console.ReadLine();
        Console.WriteLine("Enter Location =>");
        department.Location = Console.ReadLine();
       Console.WriteLine(_departmentService.AddDepartment(department));
    }

    private void DeleteDepartment()
    {
        Console.WriteLine("Enter the Department Id=>");
        int id = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine(_departmentService.DeleteById(id));
    }

    private void UpdateDepartment()
    {
        DepartmentResponseModel department = new DepartmentResponseModel();
        Console.WriteLine("Enter Id =>");
        department.Id = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter Department Name =>");
        department.DepartmentName = Console.ReadLine();
        Console.WriteLine("Enter Location =>");
        department.Location = Console.ReadLine();
        Console.WriteLine( _departmentService.UpdateDepartment(department));
    }

    private void PrintAll()
    {
        IEnumerable<DepartmentResponseModel> departments = _departmentService.GetAllDepartments();

        foreach (var department in departments)
        {
            Console.WriteLine(department.Id + "\t" + department.DepartmentName + "\t"+department.Location );
        }
        
    }

    private void PrintDepartmentById()
    {
        Console.WriteLine("Enter the Department Id=>");
        int id = Convert.ToInt32(Console.ReadLine());
        DepartmentResponseModel department = _departmentService.GetById(id);
        Console.WriteLine(department.Id + "\t" + department.DepartmentName + "\t"+department.Location );
    }
    
    public void Run()
    {
        PrintAll();
    }
}