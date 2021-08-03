using AutoMapper;
using SynetecAssessmentApi.Application.Company.Responses.GetAllEmployees;
using SynetecAssessmentApi.Application.Company.Responses.GetCompanyBonusPool;
using SynetecAssessmentApi.Application.Company.Responses.GetEmployeeBonus;
using SynetecAssessmentApi.Domain;

namespace SynetecAssessmentApi.Application.Profiles
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Domain.Company, GetCompanyBonusPoolResponse>();
            
            CreateMap<Employee, EmployeeResponse>();

            CreateMap<Department, DepartmentResponse>();
            
            CreateMap<Department, EmployeeBonusDepartmentResponse>();

            CreateMap<Employee, EmployeeBonusResponse>()
                .ForMember(x => x.Bonus, dest => dest.Ignore());
        }
    }
}