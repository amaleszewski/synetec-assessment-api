using SynetecAssessmentApi.Application.Abstraction;

namespace SynetecAssessmentApi.Application.BonusPool.Responses.GetEmployeeBonus
{
    public class EmployeeBonusResponse : IResponse
    {
        public int EmployeeId { get; private set; }

        public int Salary { get; private set; }
        
        public string Fullname { get; private set; }
        
        public int Amount { get; private set; }

        public void SetAmount(int amount)
        {
            Amount = amount;
        }
    }
}