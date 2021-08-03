using MediatR;

namespace SynetecAssessmentApi.Application.Company.Requests
{
    public class UpdateCompanyBonusPoolRequest : IRequest
    {
        public UpdateCompanyBonusPoolRequest(int bonusPool)
        {
            BonusPool = bonusPool;
        }

        public int BonusPool { get; private set; }
    }
}