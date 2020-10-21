using System.Threading.Tasks;
using OneLinkTest.Application.Extensions;
using OneLinkTest.Application.Services;
using OneLinkTest.Domain.Employees;

namespace OneLinkTest.Application.UseCases.Employees.AddEmployee
{
    public class AddEmployeeValidationUseCase : IAddEmployeeUseCase
    {
        private readonly IAddEmployeeUseCase _useCase;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly Notification _notification;
        private IOutputPort _outputPort;
        private readonly InputValidator _validator;

        public AddEmployeeValidationUseCase(IAddEmployeeUseCase useCase,
            IEmployeeRepository employeeRepository,
            Notification notification)
        {
            _useCase = useCase;
            _employeeRepository = employeeRepository;
            _notification = notification;
            _outputPort = new AddEmployeePresenter();
            _validator = new InputValidator();
        }

        public void SetOutputPort(IOutputPort outputPort)
        {
            _outputPort = outputPort;
            _useCase.SetOutputPort(outputPort);
        }

        public async Task Execute(Input input)
        {
            var employee = await _employeeRepository.Find(input.Document, input.DocumentType);

            if (employee != null)
            {
                _outputPort.Conflict();
                return;
            }

            var result = _validator.Validate(input);

            if (!result.IsValid)
            {
                _outputPort.Invalid();
                _notification.AddValidationResult(result);
                return;
            }

            await _useCase.Execute(input);
        }
    }
}
