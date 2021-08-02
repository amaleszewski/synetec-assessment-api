using SynetecAssessmentApi.Application.Abstraction;
using SynetecAssessmentApi.Application.BonusPool.Responses.GetEmployeeBonus;

namespace SynetecAssessmentApi.Application.BonusPool.Queries
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