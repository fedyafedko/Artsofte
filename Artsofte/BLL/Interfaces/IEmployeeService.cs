using Employer.Common.DTO;

namespace BLL.Interfaces;

public interface IEmployeeService
{
    Task<AddEmployeeDTO> AddEmployer(AddEmployeeDTO addEmployee);
    List<EmployeeDTO> GetAll();
    Task<UpdateEmployeeDTO> UpdateEmployer(UpdateEmployeeDTO addEmployee, int id);
    Task<bool> DeleteEmployer(int id);
}