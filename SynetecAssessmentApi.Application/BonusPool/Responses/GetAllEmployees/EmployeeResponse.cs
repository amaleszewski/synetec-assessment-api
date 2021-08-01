using SynetecAssessmentApi.Application.Abstraction;

namespace SynetecAssessmentApi.Application.BonusPool.Responses.GetAllEmployees
{
	public class EmployeeResponse : IResponse
	{
		public int Id { get; private set; }

		public string Fullname { get; private set; }
		
		public string JobTitle { get; private set; }
		
		public int Salary { get; private set; }
		
		public DepartmentResponse Department { get; private set; }
	}
}
