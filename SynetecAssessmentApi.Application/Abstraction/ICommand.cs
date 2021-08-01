using MediatR;

namespace SynetecAssessmentApi.Application.Abstraction
{
	public interface ICommand : ICommand<Unit>
	{
	}

	public interface ICommand<TResult> : IRequest<TResult>
	{
	}
}
