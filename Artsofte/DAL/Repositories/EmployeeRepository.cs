using DAL.EF;
using DAL.Entities;
using DAL.Repositories.Base;
using DAL.Repositories.Interfaces;

namespace DAL.Repositories;

public class EmployeeRepository : Repo<Employee, string>, IEmployeeRepository
{
    public EmployeeRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext) { }
}