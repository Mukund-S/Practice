using EntityFramework.Core.Entities;
using EntityFramework.Core.Interfaces.Services;
using EntityFramework.Core.Models.RequestModel;
using EntityFramework.Core.Models.ResponseModel;
using EntityFramework.Infrastructure.Repositories;

namespace EntityFramework.Infrastructure.Services;

public class DepartmentService: IDepartmentService
{
    private DepartmentRepository _departmentRepository = new DepartmentRepository();
    public List<DepartmentResponseModel> GetAllDepartments()
    {
        var departments = _departmentRepository.GetAll();
        var departmentResponse = new List<DepartmentResponseModel>();
        foreach (var department in departments)
        {
            departmentResponse.Add(new DepartmentResponseModel
            {
                DepartmentName = department.DepartmentName,
                Location  = department.Location,
                Id = department.Id
            });
        }

        return departmentResponse;
    }

    public DepartmentResponseModel GetById(int id)
    {
        var Department = _departmentRepository.GetById(id);
        if (Department != null)
        {
            DepartmentResponseModel model = new DepartmentResponseModel();
            model.DepartmentName = Department.DepartmentName;
            model.Location = Department.Location;
            model.Id = Department.Id;
            return model;
        }

        return null;
    }

    public int AddDepartment(DepartmentRequestModel model)
    {
        Department dept = new Department()
        {
            DepartmentName = model.DepartmentName,
            Location = model.Location
        };
        return _departmentRepository.Insert(dept);
    }

    public int UpdateDepartment(DepartmentResponseModel model)
    {
        return _departmentRepository.Update(new Department()
        {
            DepartmentName = model.DepartmentName,
            Location = model.Location,
            Id= model.Id
        });
    }

    public int DeleteById(int id)
    {
        return _departmentRepository.DeleteById(id);
    }
}