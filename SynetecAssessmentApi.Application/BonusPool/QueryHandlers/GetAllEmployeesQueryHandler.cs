using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using SynetecAssessmentApi.Application.Abstraction;
using SynetecAssessmentApi.Application.BonusPool.Queries;
using SynetecAssessmentApi.Application.BonusPool.Responses.GetAllEmployees;

namespace SynetecAssessmentApi.Application.BonusPool.QueryHandlers
{
	public class GetAllEmployeesQueryHandler : IQueryHandler<GetAllEmployeesQuery, IList<EmployeeResponse>>
	{

		public Task<IList<EmployeeResponse>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
		{
			throw new System.NotImplementedException();
		}
	}
}
