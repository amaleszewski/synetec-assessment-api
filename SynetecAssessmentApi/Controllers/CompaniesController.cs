using System.Collections.Generic;
using System.Threading;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MediatR;
using SynetecAssessmentApi.Application.Company.Commands;
using SynetecAssessmentApi.Application.Company.Queries;
using SynetecAssessmentApi.Application.Company.Requests;
using SynetecAssessmentApi.Application.Company.Responses.GetAllEmployees;
using SynetecAssessmentApi.Application.Company.Responses.GetEmployeeBonus;

namespace SynetecAssessmentApi.Controllers
{
    // TODO: Add unit tests
    // TODO: Write my remarks
    [ApiController]
    [Route("api/[controller]")]
    public class CompaniesController : Controller
    {
        private readonly IMediator _mediator;

        public CompaniesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get all employees for given company
        /// </summary>
        /// <param name="id">Id of the company</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>List of employees</returns>
        [HttpGet("{id:int}/Employees")]
        public Task<List<EmployeeResponse>> GetAllCompanyEmployees(int id, CancellationToken cancellationToken)
        {
            var query = new GetAllEmployeesQuery(id);

            return _mediator.Send(query, cancellationToken);
        }

        /// <summary>
        /// Get company employee with bonus
        /// </summary>
        /// <param name="id">Id of the company</param>
        /// <param name="employeeId">Id of the employee</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        [HttpGet("{id:int}/Employees/{employeeId:int}")]
        public Task<EmployeeBonusResponse> GetCompanyEmployeeWithBonus(int id, int employeeId, CancellationToken cancellationToken)
        {
            var query = new GetEmployeeBonusQuery(id, employeeId);

            return _mediator.Send(query, cancellationToken);
        }

        /// <summary>
        /// Update company bonus pool
        /// </summary>
        /// <param name="id">Id of the company</param>
        /// <param name="request">Request which contains parameters for updating company</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        [HttpPatch("{id:int}/BonusPool")]
        public Task UpdateCompanyBonusPool(int id, [FromBody] UpdateCompanyBonusPoolRequest request, CancellationToken cancellationToken)
        {
            var command = new UpdateCompanyBonusPoolCommand(id, request.BonusPool);

            return _mediator.Send(command, cancellationToken);
        }
    }
}
