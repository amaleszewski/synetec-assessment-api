namespace SynetecAssessmentApi.Domain.Services.Abstraction
{
    public interface IEmployeeBonusCalculator
    {
        decimal Calculate(int salary, int totalCompanyWages, int companyBonusPool);
    }
}