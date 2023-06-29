using Employer.Common.DTO.Department;

namespace BLL.Interfaces;

public interface IDepartmentService
{
    Task<DepartmentDTO> AddDepartment(DepartmentDTO language);
    List<DepartmentDTO> GetAll();
    Task<DepartmentDTO> UpdateDepartment(DepartmentDTO language, int id);
    Task<bool> DeleteDepartment(int id);
}