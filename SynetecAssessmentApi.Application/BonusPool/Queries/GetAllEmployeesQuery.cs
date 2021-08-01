using System.Collections.Generic;
using SynetecAssessmentApi.Application.Abstraction;
using SynetecAssessmentApi.Application.BonusPool.Responses.GetAllEmployees;

namespace SynetecAssessmentApi.Application.BonusPool.Queries
{
	public class GetAllEmployeesQuery : IQuery<IList<EmployeeResponse>>
	{
	}
}
