using System.Threading;
using System.Threading.Tasks;
using SynetecAssessmentApi.Application.Abstraction;
using SynetecAssessmentApi.Application.Abstraction.Repositories;
using SynetecAssessmentApi.Application.Company.Queries;
using SynetecAssessmentApi.Application.Company.Responses.GetCompanyBonusPool;
using SynetecAssessmentApi.Application.Company.Responses.GetEmployeeBonus;

namespace SynetecAssessmentApi.Application.Company.QueryHandlers
{
    public class GetEmployeeBonusQueryHandler : IQueryHandler<GetEmployeeBonusQuery, EmployeeBonusResponse>
    {
        private readonly ICompaniesRepository _companiesRepository;

        public GetEmployeeBonusQueryHandler(ICompaniesRepository companiesRepository)
        {
            _companiesRepository = companiesRepository;
        }

        public async Task<EmployeeBonusResponse> Handle(GetEmployeeBonusQuery query, CancellationToken cancellationToken)
        {
            var company =
                await _companiesRepository.GetAsync<GetCompanyBonusPoolResponse>(query.CompanyId, cancellationToken);
            
            var annualCompanyWages = await _companiesRepository.GetCompanyAnnualWagesAsync(query.CompanyId, cancellationToken);

            var employee =
                await _companiesRepository.GetCompanyEmployeeAsync<EmployeeBonusResponse>(query.CompanyId,
                    query.EmployeeId, cancellationToken);
            
            //TODO: Extract logic to another class and register in DI
            var bonusPercentage = (decimal)employee.Salary / annualCompanyWages;

            //TODO: Rethink what details we want in singular employee response model
            employee.SetBonus((int) (bonusPercentage * company.AnnualBonusPool));
            
            return employee;
        }
    }
}