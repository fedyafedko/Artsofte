﻿namespace Employee.Common.DTO;

public class UpdateEmployeeDTO
{
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public int Age { get; set; }
    public int DepartmentFloor { get; set; }
    public string LanguageName { get; set; } = string.Empty;
}