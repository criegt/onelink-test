using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OneLinkTest.Application.Services;
using OneLinkTest.Application.UseCases.Employees.AddEmployee;
using OneLinkTest.Domain.Employees;

namespace OneLinkTest.WebApi.Controllers.V1.Employees.AddEmployee
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public sealed class EmployeesController : ControllerBase, IOutputPort
    {
        private readonly Notification _notification;
        private IActionResult _viewModel;

        public EmployeesController(Notification notification)
        {
            _notification = notification;
        }

        void IOutputPort.Conflict()
        {
            var problemDetails = new ProblemDetails
            {
                Detail = "There is already an employee registered with the same document"
            };
            _viewModel = Conflict(problemDetails);
        }

        void IOutputPort.Invalid()
        {
            var problemDetails = new ValidationProblemDetails(_notification.ModelState);
            _viewModel = BadRequest(problemDetails);
        }

        void IOutputPort.Ok(Employee employee)
        {
            _viewModel = NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Post(
            [FromServices] IAddEmployeeUseCase useCase,
            [FromBody][Required] Input input)
        {
            useCase.SetOutputPort(this);

            await useCase.Execute(input)
                .ConfigureAwait(false);

            return _viewModel;
        }
    }
}
