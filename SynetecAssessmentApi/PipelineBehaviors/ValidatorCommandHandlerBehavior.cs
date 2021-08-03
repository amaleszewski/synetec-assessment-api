using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using SynetecAssessmentApi.Application.Abstraction;

namespace SynetecAssessmentApi.PipelineBehaviors
{
	public class ValidatorCommandHandlerBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
		where TRequest : ICommand
	{
		private readonly IValidator<TRequest> _validator;

		public ValidatorCommandHandlerBehavior(IValidator<TRequest> validator)
		{
			_validator = validator;
		}

		public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
		{
			var validationResult = await _validator.ValidateAsync(request, cancellationToken);
			
			if (!validationResult.IsValid)
			{
				throw new ValidationException(validationResult.Errors);
			}

			return await next();
		}
	}
}
