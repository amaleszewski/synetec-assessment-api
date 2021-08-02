using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using SynetecAssessmentApi.Application.Abstraction;
using SynetecAssessmentApi.Application.Abstraction.Repositories;
using SynetecAssessmentApi.Application.BonusPool.Queries;
using SynetecAssessmentApi.Application.BonusPool.Responses.GetAllEmployees;

namespace SynetecAssessmentApi.Application.BonusPool.QueryHandlers
{
	public class GetAllEmployeesQueryHandler : IQueryHandler<GetAllEmployeesQuery, List<EmployeeResponse>>
	{
		private readonly ICompaniesRepository _companiesRepository;

		public GetAllEmployeesQueryHandler(ICompaniesRepository companiesRepository)
		{
			_companiesRepository = companiesRepository;
		}

		public Task<List<EmployeeResponse>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
		{
			return _companiesRepository.GetAllEmployeesAsync<EmployeeResponse>(request.CompanyId, cancellationToken);
		}
	}
}
