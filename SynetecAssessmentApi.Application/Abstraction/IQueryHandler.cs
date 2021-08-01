using MediatR;

namespace SynetecAssessmentApi.Application.Abstraction
{
	public interface IQueryHandler<in TQuery, TResult> : IRequestHandler<TQuery, TResult> where TQuery : IQuery<TResult>
	{
	}
}
