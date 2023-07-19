using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities;

public class Employee
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public int Age { get; set; }
        
    [ForeignKey("Gender")]
    public string Gender { get; set; } = string.Empty;

    [ForeignKey("Department")]
    public int DepartmentFloor { get; set; }

    [ForeignKey("Language")]
    public string LanguageName { get; set; } = string.Empty;

    public virtual Department? Department { get; set; }
    public virtual ProgrammingLanguage? Language { get; set; }
}

public enum Gender
{
    Male,
    Female
}

public class Department
{
    [Key]
    public int Floor { get; set; }
    public string Name { get; set; } = string.Empty;

    public virtual ICollection<Employee>? Employees { get; set; }
}

public class ProgrammingLanguage
{
    [Key]
    public string Name { get; set; } = string.Empty;

    public virtual ICollection<Employee>? Employees { get; set; }
}