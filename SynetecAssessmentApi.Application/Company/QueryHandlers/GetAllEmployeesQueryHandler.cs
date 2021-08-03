using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using SynetecAssessmentApi.Application.Abstraction;
using SynetecAssessmentApi.Application.Abstraction.Repositories;
using SynetecAssessmentApi.Application.Company.Queries;
using SynetecAssessmentApi.Application.Company.Responses.GetAllEmployees;

namespace SynetecAssessmentApi.Application.Company.QueryHandlers
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
