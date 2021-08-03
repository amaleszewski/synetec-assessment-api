using FluentValidation;
using SynetecAssessmentApi.Application.Company.Commands;

namespace SynetecAssessmentApi.Application.Company.Validators
{
    public class UpdateCompanyBonusPoolCommandValidator : AbstractValidator<UpdateCompanyBonusPoolCommand>
    {
        public UpdateCompanyBonusPoolCommandValidator()
        {
            RuleFor(x => x.BonusPool).NotEmpty();

            RuleFor(x => x.CompanyId).NotEmpty();
        }
    }
}