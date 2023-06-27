using BLL.Interfaces;
using Employer.Common.DTO;

namespace BLL.Service;

public class EmployerService : IEmployerService
{
    public Task<EmployerDTO> AddEmployer(EmployerDTO employer)
    {
        throw new NotImplementedException();
    }

    public List<EmployerDTO> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<EmployerDTO> UpdateEmployer(EmployerDTO employer, int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteEmployer(int id)
    {
        throw new NotImplementedException();
    }
}