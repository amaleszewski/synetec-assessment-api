using System.Collections.Generic;
using SynetecAssessmentApi.Application.Abstraction;
using SynetecAssessmentApi.Application.BonusPool.Responses.GetAllEmployees;

namespace SynetecAssessmentApi.Application.BonusPool.Queries
{
	public class GetAllEmployeesQuery : IQuery<List<EmployeeResponse>>
	{
		public GetAllEmployeesQuery(int companyId)
		{
			CompanyId = companyId;
		}

		public int CompanyId { get; }
	}
}
