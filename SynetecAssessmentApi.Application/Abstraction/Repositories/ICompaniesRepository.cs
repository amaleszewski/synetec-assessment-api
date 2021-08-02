using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using SynetecAssessmentApi.Domain;

namespace SynetecAssessmentApi.Application.Abstraction.Repositories
{
    public interface ICompaniesRepository : IRepository<Company>
    {
        Task<List<TResponse>> GetAllEmployeesAsync<TResponse>(int companyId, CancellationToken cancellationToken)
            where TResponse : IResponse;

        Task<int> GetCompanyAnnualWagesAsync(int companyId, CancellationToken cancellationToken);

        Task<TResponse> GetCompanyEmployeeAsync<TResponse>(int companyId, int employeeId,
            CancellationToken cancellationToken) where TResponse : IResponse;
    }
}