using AutoMapper;
using SynetecAssessmentApi.Application.BonusPool.Responses.GetAllEmployees;
using SynetecAssessmentApi.Application.BonusPool.Responses.GetCompanyBonusPool;
using SynetecAssessmentApi.Application.BonusPool.Responses.GetEmployeeBonus;
using SynetecAssessmentApi.Domain;

namespace SynetecAssessmentApi.Application.Profiles
{
    // TODO: Rename and move to BonusPool folder ?
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Company, GetCompanyBonusPoolResponse>();
            
            CreateMap<Employee, EmployeeResponse>();

            CreateMap<Department, DepartmentResponse>();

            CreateMap<Employee, EmployeeBonusResponse>()
                .ForMember(x => x.EmployeeId, dest => dest.MapFrom(x => x.Id))
                .ForMember(x => x.Amount, dest => dest.Ignore());
        }
    }
}