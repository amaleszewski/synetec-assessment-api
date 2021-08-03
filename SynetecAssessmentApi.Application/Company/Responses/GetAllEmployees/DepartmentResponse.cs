using SynetecAssessmentApi.Application.Abstraction;

namespace SynetecAssessmentApi.Application.Company.Responses.GetAllEmployees
{
	public class DepartmentResponse : IResponse
	{
		public string Title { get; private set; }
		
		public string Description { get; private set; }
	}
}
