using Employer.Common.DTO;

namespace BLL.Interfaces;

public interface IEmployerService
{
    Task<AddEmployerDTO> AddEmployer(AddEmployerDTO addEmployer);
    List<EmployerDTO> GetAll();
    Task<UpdateEmployerDTO> UpdateEmployer(UpdateEmployerDTO addEmployer, int id);
    Task<bool> DeleteEmployer(int id);
    Task<EmployerDTO?> GetById(int id);
}