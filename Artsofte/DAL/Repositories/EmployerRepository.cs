using DAL.EF;
using DAL.Entities;
using DAL.Repositories.Base;
using DAL.Repositories.Interfaces;

namespace DAL.Repositories;

public class EmployerRepository : Repo<Employer, string>, IEmployerRepository
{
    public EmployerRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext) { }
}