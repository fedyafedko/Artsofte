using BLL.Interfaces;
using DAL.EF;
using Employee.Common.DTO;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace BLL.Service;

public class EmployeeService : IEmployeeService
{
    private readonly ApplicationDbContext _applicationDbContext;

    public EmployeeService(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext ?? throw new ArgumentNullException(nameof(applicationDbContext));
    }

    public async Task<AddEmployeeDTO> AddEmployee(AddEmployeeDTO employee)
    {
        await _applicationDbContext.Database.ExecuteSqlRawAsync(
            "EXEC AddEmployee @Name, @Surname, @Age, @Gender, @DepartmentFloor, @LanguageName",
            new SqlParameter("@Name", employee.Name),
            new SqlParameter("@Surname", employee.Surname),
            new SqlParameter("@Age", employee.Age),
            new SqlParameter("@Gender", employee.Gender.ToString()),
            new SqlParameter("@DepartmentFloor", employee.DepartmentFloor),
            new SqlParameter("@LanguageName", employee.LanguageName)
        );

        return employee;
    }

    public List<DAL.Entities.Employee> GetAll()
    {
        return _applicationDbContext.Employees.FromSqlRaw("GetAllEmployee").ToList();
    }

    public async Task<UpdateEmployeeDTO> UpdateEmployee(UpdateEmployeeDTO employee, int id)
    {
        await _applicationDbContext.Database.ExecuteSqlRawAsync(
            "EXEC UpdateEmployee @Id, @Name, @Surname, @Age, @DepartmentFloor, @LanguageName",
            new SqlParameter("@Id", id),
            new SqlParameter("@Name", employee.Name),
            new SqlParameter("@Surname", employee.Surname),
            new SqlParameter("@Age", employee.Age),
            new SqlParameter("@DepartmentFloor", employee.DepartmentFloor),
            new SqlParameter("@LanguageName", employee.LanguageName)
        );
        return employee;
    }

    public async Task<bool> DeleteEmployee(int id)
    {
        var employee = await _applicationDbContext.Database.ExecuteSqlRawAsync(
            "EXEC [dbo].[DeleteEmployee] @Id",
        new SqlParameter("@Id", id));
        return employee < 0;
    }
}