﻿using Employee.Common.DTO;

namespace BLL.Interfaces;

public interface IEmployeeService
{
    Task<AddEmployeeDTO> AddEmployee(AddEmployeeDTO employee);
    List<EmployeeDTO> GetAll();
    Task<EmployeeDTO?> GetById(int id);
    Task<UpdateEmployeeDTO> UpdateEmployee(UpdateEmployeeDTO employee, int id);
    Task<bool> DeleteEmployee(int id);
}