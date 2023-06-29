using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF;

public class ApplicationDbContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }
    public DbSet<ProgrammingLanguage> Languages { get; set; }
    public DbSet<Department> Departments { get; set; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}
}