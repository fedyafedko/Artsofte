using Employee.Common.DTO.Department;

namespace BLL.Interfaces;

public interface IDepartmentService
{
    Task<DepartmentDTO> AddDepartment(DepartmentDTO department);
    List<DepartmentDTO> GetAll();
    Task<DepartmentDTO> UpdateDepartment(DepartmentDTO department, int id);
    Task<bool> DeleteDepartment(int id);
}