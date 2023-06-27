using AutoMapper;
using Employer.Common.DTO;

namespace BLL.AutoMapper;

public class EmployerProfile : Profile
{
    public EmployerProfile()
    {
        CreateMap<AddEmployerDTO, DAL.Entities.Employer>().ReverseMap();
        CreateMap<EmployerDTO, DAL.Entities.Employer>().ReverseMap();
        CreateMap<UpdateEmployerDTO, DAL.Entities.Employer>().ReverseMap();
        CreateMap<Department, DAL.Entities.Department>().ReverseMap();
        CreateMap<ProgrammingLanguage, DAL.Entities.ProgrammingLanguage>().ReverseMap();
    }
}