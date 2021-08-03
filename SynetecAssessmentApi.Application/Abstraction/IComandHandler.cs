using MediatR;

namespace SynetecAssessmentApi.Application.Abstraction
{
	public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand> where TCommand : ICommand
	{
	}
}
