using AutoMapper;
using Employer.Common.DTO;

namespace BLL.AutoMapper;

public class EmployerProfile : Profile
{
    public EmployerProfile()
    {
        CreateMap<EmployerDTO, DAL.Entities.Employer>().ReverseMap();
    }
}