namespace Employer.Common.DTO;

public class UpdateEmployerDTO
{
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public int Age { get; set; }
    public int DepartmentId { get; set; }
    public int LanguageId { get; set; }
}