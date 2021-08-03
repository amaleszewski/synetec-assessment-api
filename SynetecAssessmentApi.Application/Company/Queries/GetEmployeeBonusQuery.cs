using SynetecAssessmentApi.Application.Abstraction;
using SynetecAssessmentApi.Application.Company.Responses.GetEmployeeBonus;

namespace SynetecAssessmentApi.Application.Company.Queries
{
    public class GetEmployeeBonusQuery : IQuery<EmployeeBonusResponse>
    {
        public GetEmployeeBonusQuery(int companyId, int employeeId)
        {
            CompanyId = companyId;
            EmployeeId = employeeId;
        }

        public int CompanyId { get; }

        public int EmployeeId { get; }
    }
}