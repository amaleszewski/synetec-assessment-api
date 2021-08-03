using FluentValidation;
using SynetecAssessmentApi.Application.Company.Queries;

namespace SynetecAssessmentApi.Application.Company.Validators
{
    public class GetEmployeeBonusQueryValidator : AbstractValidator<GetEmployeeBonusQuery>
    {
        public GetEmployeeBonusQueryValidator()
        {
            RuleFor(x => x.CompanyId).NotEmpty();

            RuleFor(x => x.EmployeeId).NotEmpty();
        }
    }
}