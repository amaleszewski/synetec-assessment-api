using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using SynetecAssessmentApi.Application.Abstraction.Exceptions;

namespace SynetecAssessmentApi
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            switch (context.Exception)
            {
                case INotFound _:
                    context.Result = new NotFoundObjectResult(
                        new
                        {
                            context.Exception.Message,
                        });
                    context.ExceptionHandled = true;

                    break;
                case ValidationException validationException:
                    var result = new ValidationResult(validationException.Errors);

                    result.AddToModelState(context.ModelState, null);

                    context.Result = new BadRequestObjectResult(context.ModelState);
                    context.ExceptionHandled = true;

                    break;
            }
        }
    }
}