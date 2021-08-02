using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MediatR;
using SynetecAssessmentApi.Application.BonusPool.Queries;
using SynetecAssessmentApi.Application.BonusPool.Responses.GetAllEmployees;
using SynetecAssessmentApi.Application.BonusPool.Responses.GetEmployeeBonus;

namespace SynetecAssessmentApi.Controllers
{
    // TODO: Add versioning
    // TODO: Rename queries to have exact good naming
    // TODO: Add summaries for endpoints
    // TODO: Add endpoint for changing annual pool bonus
    [ApiController]
    [Route("api/[controller]")]
    public class CompaniesController : Controller
    {
        private readonly IMediator _mediator;

        public CompaniesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id:int}/Employees")]
        public Task<List<EmployeeResponse>> GetAllCompanyEmployees(int id)
        {
            var query = new GetAllEmployeesQuery(id);

            return _mediator.Send(query);
        }

        [HttpGet("{id:int}/Employees/{employeeId:int}")]
        public Task<EmployeeBonusResponse> GetCompanyEmployeeWithBonus(int id, int employeeId)
        {
            var query = new GetEmployeeBonusQuery(id, employeeId);

            return _mediator.Send(query);
        }
    }
}
