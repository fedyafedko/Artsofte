using AutoMapper;
using Employer.Common.DTO;
using Employer.Common.DTO.Department;
using Employer.Common.DTO.Language;

namespace BLL.AutoMapper;

public class EmployeeProfile : Profile
{
    public EmployeeProfile()
    {
        CreateMap<AddEmployeeDTO, DAL.Entities.Employee>().ReverseMap();
        CreateMap<EmployeeDTO, DAL.Entities.Employee>().ReverseMap();
        CreateMap<UpdateEmployeeDTO, DAL.Entities.Employee>().ReverseMap();
        CreateMap<DepartmentDTO, DAL.Entities.Department>().ReverseMap();
        CreateMap<LanguageDTO, DAL.Entities.ProgrammingLanguage>().ReverseMap();
    }
}