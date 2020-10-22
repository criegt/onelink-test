using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OneLinkTest.Application.Services;
using OneLinkTest.Application.UseCases.Employees.UpdateEmployee;
using OneLinkTest.Domain.Employees;

namespace OneLinkTest.WebApi.Controllers.V1.Employees.UpdateEmployee
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase, IOutputPort
    {
        private readonly Notification _notification;
        private IActionResult _viewModel;
        public EmployeesController(Notification notification)
        {
            _notification = notification;
        }

        void IOutputPort.Invalid()
        {
            var problemDetails = new ValidationProblemDetails(_notification.ModelState);
            _viewModel = BadRequest(problemDetails);
        }

        void IOutputPort.NotFound()
        {
            _viewModel = NotFound();
        }

        void IOutputPort.Ok(Employee employee)
        {
            _viewModel = NoContent();
        }

        [HttpPut("{employeeId:int}")]
        public async Task<IActionResult> Put(
            [FromServices] IUpdateEmployeeUseCase useCase,
            [FromBody][Required] Input input,
            [Required] int employeeId)
        {
            input.EmployeeId = employeeId;

            useCase.SetOutputPort(this);

            await useCase.Execute(input)
                .ConfigureAwait(false);

            return _viewModel;
        }
    }
}
