namespace Employer.Common.DTO;

public class UpdateEmployeeDTO
{
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public int Age { get; set; }
    public int DepartmentId { get; set; }
    public int LanguageId { get; set; }
}