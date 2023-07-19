using Employee.Common.DTO;

namespace BLL.Interfaces;

public interface IEmployeeService
{
    Task<AddEmployeeDTO> AddEmployee(AddEmployeeDTO employee);
    List<DAL.Entities.Employee> GetAll();
    Task<UpdateEmployeeDTO> UpdateEmployee(UpdateEmployeeDTO employee, int id);
    Task<bool> DeleteEmployee(int id);
}