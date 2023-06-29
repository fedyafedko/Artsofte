using DAL.Entities;
using DAL.Repositories.Base;

namespace DAL.Repositories.Interfaces;

public interface IEmployeeRepository : IRepo<Employee, string>
{
    
}