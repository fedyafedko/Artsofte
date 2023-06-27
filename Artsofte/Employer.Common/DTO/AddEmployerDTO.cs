namespace Employer.Common.DTO;

public class AddEmployerDTO
{
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public int Age { get; set; }
    public Gender Gender { get; set; }
    public Department Department { get; set; }
    public ProgrammingLanguage Language { get; set; }
}
public enum Gender
{
    Male,
    Female
}
public class Department
{
    public string Name { get; set; } = string.Empty;
    public int Floor { get; set; }
}

public class ProgrammingLanguage
{
    public string Name { get; set; } = String.Empty;
}