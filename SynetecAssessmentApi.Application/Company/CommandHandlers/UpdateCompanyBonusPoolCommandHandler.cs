using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SynetecAssessmentApi.Application.Abstraction;
using SynetecAssessmentApi.Application.Abstraction.Repositories;
using SynetecAssessmentApi.Application.Company.Commands;

namespace SynetecAssessmentApi.Application.Company.CommandHandlers
{
    public class UpdateCompanyBonusPoolCommandHandler : ICommandHandler<UpdateCompanyBonusPoolCommand>
    {
        private readonly ICompaniesRepository _companiesRepository;

        public UpdateCompanyBonusPoolCommandHandler(ICompaniesRepository companiesRepository)
        {
            _companiesRepository = companiesRepository;
        }

        public async Task<Unit> Handle(UpdateCompanyBonusPoolCommand request, CancellationToken cancellationToken)
        {
            var company = await _companiesRepository.GetAsync(request.CompanyId, cancellationToken);

            company.ChangeAnnualBonusPool(request.BonusPool);

            _companiesRepository.Update(company);
            
            return Unit.Value;
        }
    }
}