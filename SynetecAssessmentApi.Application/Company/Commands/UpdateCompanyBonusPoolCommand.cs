using SynetecAssessmentApi.Application.Abstraction;

namespace SynetecAssessmentApi.Application.Company.Commands
{
    public class UpdateCompanyBonusPoolCommand : ICommand
    {
        public UpdateCompanyBonusPoolCommand(int companyId, int bonusPool)
        {
            CompanyId = companyId;
            BonusPool = bonusPool;
        }

        public int CompanyId { get; }

        public int BonusPool { get; }
    }
}