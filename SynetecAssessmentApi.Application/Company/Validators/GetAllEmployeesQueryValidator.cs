using FluentValidation;
using SynetecAssessmentApi.Application.Company.Queries;

namespace SynetecAssessmentApi.Application.Company.Validators
{
    public class GetAllEmployeesQueryValidator : AbstractValidator<GetAllEmployeesQuery>
    {
        public GetAllEmployeesQueryValidator()
        {
            RuleFor(x => x.CompanyId).NotEmpty();
        }
    }
}