using Employer.Common.DTO;

namespace BLL.Interfaces;

public interface IEmployerService
{
    Task<EmployerDTO> AddEmployer(EmployerDTO employer);
    List<EmployerDTO> GetAll();
    Task<EmployerDTO> UpdateEmployer(EmployerDTO employer, int id);
    Task<bool> DeleteEmployer(int id);
}