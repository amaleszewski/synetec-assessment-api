using MediatR;

namespace SynetecAssessmentApi.Application.Abstraction
{
	public interface IQuery<TResult> : IRequest<TResult> 
	{
	}
}
