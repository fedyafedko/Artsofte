namespace Employer.Common.DTO;

public class AddEmployeeDTO
{
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public int Age { get; set; }
    public Gender Gender { get; set; }
    public int Department { get; set; }
    public string LanguageName { get; set; } = string.Empty;
}
public enum Gender
{
    Male,
    Female
}
