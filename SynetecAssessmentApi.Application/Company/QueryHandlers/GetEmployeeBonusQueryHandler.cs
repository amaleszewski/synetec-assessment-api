using System.Threading;
using System.Threading.Tasks;
using SynetecAssessmentApi.Application.Abstraction;
using SynetecAssessmentApi.Application.Abstraction.Repositories;
using SynetecAssessmentApi.Application.Company.Queries;
using SynetecAssessmentApi.Application.Company.Responses.GetCompanyBonusPool;
using SynetecAssessmentApi.Application.Company.Responses.GetEmployeeBonus;
using SynetecAssessmentApi.Domain.Services.Abstraction;

namespace SynetecAssessmentApi.Application.Company.QueryHandlers
{
    public class GetEmployeeBonusQueryHandler : IQueryHandler<GetEmployeeBonusQuery, EmployeeBonusResponse>
    {
        private readonly ICompaniesRepository _companiesRepository;
        private readonly IEmployeeBonusCalculator _employeeBonusCalculator;

        public GetEmployeeBonusQueryHandler(ICompaniesRepository companiesRepository, IEmployeeBonusCalculator employeeBonusCalculator)
        {
            _companiesRepository = companiesRepository;
            _employeeBonusCalculator = employeeBonusCalculator;
        }

        public async Task<EmployeeBonusResponse> Handle(GetEmployeeBonusQuery query, CancellationToken cancellationToken)
        {
            var company =
                await _companiesRepository.GetAsync<GetCompanyBonusPoolResponse>(query.CompanyId, cancellationToken);
            
            var annualCompanyWages = await _companiesRepository.GetCompanyAnnualWagesAsync(query.CompanyId, cancellationToken);

            var employee =
                await _companiesRepository.GetCompanyEmployeeAsync<EmployeeBonusResponse>(query.CompanyId,
                    query.EmployeeId, cancellationToken);
            
            var bonus = _employeeBonusCalculator.Calculate(employee.Salary, annualCompanyWages,
                company.AnnualBonusPool);
            
            employee.SetBonus(bonus);
            
            return employee;
        }
    }
}