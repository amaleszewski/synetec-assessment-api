﻿using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using SynetecAssessmentApi.Application.Abstraction;

namespace SynetecAssessmentApi.PipelineBehaviors
{
	public class ValidatorQueryHandlerBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
		where TRequest : IQuery<TResponse>
	{
		private readonly IValidator<TRequest> _validator;

		public ValidatorQueryHandlerBehavior(IValidator<TRequest> validator = null)
		{
			_validator = validator;
		}

		public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
		{
			if (_validator != null)
			{
				var validationResult = await _validator.ValidateAsync(request, cancellationToken);

				if (!validationResult.IsValid)
				{
					throw new ValidationException(validationResult.Errors);
				}
			}

			return await next();
		}
	}
}
