using System.Threading.Tasks;
using OneLinkTest.Domain.Employees;

namespace OneLinkTest.Application.UseCases.Employees.UpdateEmployee
{
    public class UpdateEmployeeUseCase : IUpdateEmployeeUseCase
    {
        private IOutputPort _outputPort;
        private readonly IEmployeeRepository _employeeRepository;

        public UpdateEmployeeUseCase(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
            _outputPort = new UpdateEmployeePresenter();
        }

        public void SetOutputPort(IOutputPort outputPort) => _outputPort = outputPort;

        public async Task Execute(Input input)
        {
            var employee = new Employee(EmployeeId.CreateNew(),
                input.Document,
                input.DocumentType,
                input.FirstName,
                input.LastName,
                input.SubareaId);

            await _employeeRepository.Add(employee);

            _outputPort.Ok(employee);
        }
    }
}
