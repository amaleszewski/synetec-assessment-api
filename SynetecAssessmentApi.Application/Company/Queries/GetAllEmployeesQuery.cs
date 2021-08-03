using System.Collections.Generic;
using SynetecAssessmentApi.Application.Abstraction;
using SynetecAssessmentApi.Application.Company.Responses.GetAllEmployees;

namespace SynetecAssessmentApi.Application.Company.Queries
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
