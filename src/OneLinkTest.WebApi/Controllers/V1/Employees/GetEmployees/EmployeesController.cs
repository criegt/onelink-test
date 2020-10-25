using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OneLinkTest.Application.UseCases.Employees.GetEmployees;
using OneLinkTest.Domain.Employees;

namespace OneLinkTest.WebApi.Controllers.V1.Employees.GetEmployees
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public sealed class EmployeesController : ControllerBase, IOutputPort
    {
        private IActionResult _viewModel;

        void IOutputPort.Ok(IReadOnlyList<Employee> employees)
        {
            _viewModel = Ok(employees);
        }

        [HttpGet]
        public async Task<IActionResult> Get(
            [FromServices] IGetEmployeesUseCase useCase,
            [FromQuery] int pageIndex = 0,
            [FromQuery] int pageSize = 10,
            [FromQuery] string searchTerms = "")
        {
            useCase.SetOutputPort(this);

            await useCase.Execute(new Input
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                SearchTerms = searchTerms ?? string.Empty
            });

            return _viewModel;
        }
    }
}
