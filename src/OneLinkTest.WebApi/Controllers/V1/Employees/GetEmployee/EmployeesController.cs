using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OneLinkTest.Application.UseCases.Employees.GetEmployee;
using OneLinkTest.Domain.Employees;

namespace OneLinkTest.WebApi.Controllers.V1.Employees.GetEmployee
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase, IOutputPort
    {
        private IActionResult _viewModel;

        void IOutputPort.NotFound() => _viewModel = NotFound();

        void IOutputPort.Ok(Employee employee) => _viewModel = Ok(employee);

        [HttpGet("{employeeId:int}")]
        public async Task<IActionResult> Get(
            [FromServices] IGetEmployeeUseCase useCase,
            [Required] long employeeId)
        {
            useCase.SetOutputPort(this);

            await useCase.Execute(employeeId);

            return _viewModel;
        }
    }
}
