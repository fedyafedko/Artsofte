using Employee.Common.DTO.Department;

namespace BLL.Interfaces;

public interface IDepartmentService
{
    Task<DepartmentDTO> AddDepartment(DepartmentDTO department);
    List<DAL.Entities.Department> GetAll();
    Task<UpdateDepartmentDTO> UpdateDepartment(UpdateDepartmentDTO department, int floor);
    Task<bool> DeleteDepartment(int floor);
}