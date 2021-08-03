using SynetecAssessmentApi.Application.Abstraction;

namespace SynetecAssessmentApi.Application.Company.Responses.GetCompanyBonusPool
{
    public class GetCompanyBonusPoolResponse : IResponse
    {
        public int AnnualBonusPool { get; private set; }
    }
}