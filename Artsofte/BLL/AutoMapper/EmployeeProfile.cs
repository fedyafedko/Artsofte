using AutoMapper;
using Employer.Common.DTO;

namespace BLL.AutoMapper;

public class EmployeeProfile : Profile
{
    public EmployeeProfile()
    {
        CreateMap<AddEmployeeDTO, DAL.Entities.Employee>().ReverseMap();
        CreateMap<EmployeeDTO, DAL.Entities.Employee>().ReverseMap();
        CreateMap<UpdateEmployeeDTO, DAL.Entities.Employee>().ReverseMap();
        CreateMap<Department, DAL.Entities.Department>().ReverseMap();
        CreateMap<ProgrammingLanguage, DAL.Entities.ProgrammingLanguage>().ReverseMap();
    }
}