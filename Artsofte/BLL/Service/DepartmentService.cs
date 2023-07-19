using BLL.Interfaces;
using DAL.EF;
using Employee.Common.DTO.Department;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace BLL.Service;

public class DepartmentService : IDepartmentService
{
    private readonly ApplicationDbContext _applicationDbContext;
    public DepartmentService(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext ?? throw new ArgumentNullException(nameof(applicationDbContext));
    }
    public async Task<DepartmentDTO> AddDepartment(DepartmentDTO department)
    {
        await _applicationDbContext.Database.ExecuteSqlRawAsync(
            "EXEC [dbo].[AddDepartment] @Floor, @Name",
            new SqlParameter("@Floor", department.Floor),
            new SqlParameter("@Name", department.Name));
        return department;
    }

    public List<DAL.Entities.Department> GetAll()
    {
        return _applicationDbContext.Departments.FromSqlRaw("GetAllDepartments").ToList();
    }

    public async Task<UpdateDepartmentDTO> UpdateDepartment(UpdateDepartmentDTO department, int floor)
    {
        await _applicationDbContext.Database.ExecuteSqlRawAsync(
            "EXEC [dbo].[UpdateDepartment] @Floor, @Name",
            new SqlParameter("@Floor", floor),
            new SqlParameter("@Name", department.Name));
        return department;
    }

    public async Task<bool> DeleteDepartment(int floor)
    {
        var employee = await _applicationDbContext.Database.ExecuteSqlRawAsync(
            "EXEC [dbo].[DeleteDepartment] @Floor",
            new SqlParameter("@Floor", floor));
        return employee < 0;
    }
}