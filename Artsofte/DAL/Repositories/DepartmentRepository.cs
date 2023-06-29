using DAL.EF;
using DAL.Entities;
using DAL.Repositories.Base;
using DAL.Repositories.Interfaces;

namespace DAL.Repositories;

public class DepartmentRepository : Repo<Department, string>, IDepartmentRepository
{
    public DepartmentRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext) { }
}