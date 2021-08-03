using SynetecAssessmentApi.Application.Abstraction;

namespace SynetecAssessmentApi.Application.Company.Responses.GetEmployeeBonus
{
    public class EmployeeBonusResponse : IResponse
    {
        public int Id { get; private set; }

        public string Fullname { get; private set; }
		
        public string JobTitle { get; private set; }
		
        public int Salary { get; private set; }

        public decimal Bonus { get; private set; }

        public EmployeeBonusDepartmentResponse Department { get; private set; }

        public void SetBonus(decimal bonus)
        {
            Bonus = bonus;
        }
    }
}