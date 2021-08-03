using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using SynetecAssessmentApi.Domain.Abstraction;

namespace SynetecAssessmentApi.Application.Abstraction
{
    public interface IRepository<TAggregateRoot> where TAggregateRoot : IAggregateRoot
    {
        Task<TAggregateRoot> GetAsync(int key, CancellationToken cancellationToken);
		
        Task<TResponse> GetAsync<TResponse>(int key, CancellationToken cancellationToken) where TResponse : IResponse;
        
        Task<List<TResponse>> GetAllAsync<TResponse>(CancellationToken cancellationToken) where TResponse : IResponse;
        
        TAggregateRoot Add(TAggregateRoot aggregateRoot);
		
        TAggregateRoot Update(TAggregateRoot aggregateRoot);

        TAggregateRoot Delete(TAggregateRoot aggregateRoot);
    }
}