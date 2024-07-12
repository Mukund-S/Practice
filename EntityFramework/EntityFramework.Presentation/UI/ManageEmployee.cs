using EntityFramework.Core.Models.RequestModel;
using EntityFramework.Infrastructure.Services;

namespace EntityFramework.UI;

public class ManageEmployee
{
    private EmployeeService _employeeService = new EmployeeService();

    private void AddEmployee()
    {
        EmployeeRequestModel _employeeRequestModel = new EmployeeRequestModel();
        Console.WriteLine("Please Enter Employee Name:");
        _employeeRequestModel.EmployeeName = Console.ReadLine();
        Console.WriteLine("Please Enter Employee Age:");
        _employeeRequestModel.Age = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine(_employeeService.AddEmployee(_employeeRequestModel));
    }

    private void PrintAllEmplyee()
    {
        var employees = _employeeService.GetAllEmployees();
        foreach (var employee in employees)
        {
            Console.WriteLine(employee.EmployeeName+"\t"+employee.Age);
        }
    }

    private void GetByEmployeeId()
    {
        Console.WriteLine("Please Enter Id:");
        int id = Convert.ToInt32(Console.ReadLine());
        var employee = _employeeService.GetById(id);
        Console.WriteLine(employee.EmployeeName + "\t"+employee.Age);
    }

    public void Run()
    {
        AddEmployee();
    }
}