using EntityFramework.Core.Entities;
using EntityFramework.Core.Interfaces.Services;
using EntityFramework.Core.Models.RequestModel;
using EntityFramework.Core.Models.ResponseModel;
using EntityFramework.Infrastructure.Repositories;
using Serilog;

namespace EntityFramework.Infrastructure.Services;

public class EmployeeService: IEmployeeService
{
    private EmployeeRepository _employeeRepository = new EmployeeRepository();
    public List<EmployeeResponseModel> GetAllEmployees()
    {
        var employees = _employeeRepository.GetAll();
        var employeeResponseModel = new List<EmployeeResponseModel>();
        foreach (var employee in employees)
        {
            employeeResponseModel.Add(new EmployeeResponseModel
            {
                EmployeeName = employee.EmployeeName,
                    Age = employee.Age
            });
        }
        Log.Information("All Employee has been called.");

        return employeeResponseModel;
    }

    public EmployeeResponseModel GetById(int id)
    {
        var employees = _employeeRepository.GetById(id);
        if (employees!=null)
        {
            var employeeResponseModel = new EmployeeResponseModel
            {
                EmployeeName = employees.EmployeeName,
                Age = employees.Age
            };
            return employeeResponseModel;
        }

        return null;
    }

    public int AddEmployee(EmployeeRequestModel model)
    {
        var employeeEntity = new Employee()
        {
            EmployeeName = model.EmployeeName,
            Age = model.Age,
            DepartmentId = 1
        };
        Log.Information("Employee has been added.");
        return _employeeRepository.Insert(employeeEntity);
    }
}