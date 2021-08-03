using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SynetecAssessmentApi.Application.Abstraction;

namespace SynetecAssessmentApi.PipelineBehaviors
{
	public class TransactionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
		where TRequest : ICommand
	{
		private readonly DbContext _dbContext;

		public TransactionBehavior(DbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
		{
			// here could be starting transaction, but in-memory database doesn't support it
			
			var response = await next();
			
			await _dbContext.SaveChangesAsync(cancellationToken);
			
			return response;
		}
	}
}
