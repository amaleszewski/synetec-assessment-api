using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SynetecAssessmentApi.Application.Abstraction;
using SynetecAssessmentApi.Application.Abstraction.Repositories;
using SynetecAssessmentApi.Domain;

namespace SynetecAssessmentApi.Persistence.Repositories
{
    public class CompaniesRepository : Repository<Company>, ICompaniesRepository
    {
        public CompaniesRepository(DbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public Task<List<TResponse>> GetAllEmployeesAsync<TResponse>(int companyId, CancellationToken cancellationToken)
            where TResponse: IResponse
        {
            var query = ReadOnlyEntitySet.Where(x => x.Id == companyId).SelectMany(x => x.Employees);

            return Mapper.ProjectTo<TResponse>(query).ToListAsync(cancellationToken);
        }

        public Task<int> GetCompanyAnnualWagesAsync(int companyId, CancellationToken cancellationToken)
        {
            var query = ReadOnlyEntitySet.Where(x => x.Id == companyId).SelectMany(x => x.Employees);

            return query.SumAsync(x => x.Salary, cancellationToken);
        }

        public Task<TResponse> GetCompanyEmployeeAsync<TResponse>(int companyId, int employeeId,
            CancellationToken cancellationToken) where TResponse : IResponse
        {
            var query = ReadOnlyEntitySet
                .Where(x => x.Id == companyId)
                .SelectMany(x => x.Employees)
                .Where(x => x.Id == employeeId);

            var mapped = Mapper.ProjectTo<TResponse>(query);

            return MapExceptionAsync<Employee, TResponse>(mapped.SingleAsync(cancellationToken), employeeId);
        }
    }
}