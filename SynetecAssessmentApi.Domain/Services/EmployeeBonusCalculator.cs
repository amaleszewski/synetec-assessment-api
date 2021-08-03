using System;
using SynetecAssessmentApi.Domain.Abstraction;
using SynetecAssessmentApi.Domain.Services.Abstraction;

namespace SynetecAssessmentApi.Domain.Services
{
    public class EmployeeBonusCalculator : IEmployeeBonusCalculator, IDomainService
    {
        public decimal Calculate(int salary, int totalCompanyWages, int companyBonusPool)
        {
            if (totalCompanyWages == 0)
            {
                return 0;
            }
            
            var bonusPercentage = (decimal)salary / totalCompanyWages;

            return decimal.Round((bonusPercentage * companyBonusPool), 2, MidpointRounding.AwayFromZero);
        }
    }
}