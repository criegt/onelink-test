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
            var employee = await _employeeRepository.Find(input.EmployeeId);

            if (employee is null)
            {
                _outputPort.NotFound();
                return;
            }

            employee.Document = input.Document;
            employee.DocumentType = input.DocumentType;
            employee.FirstName = input.FirstName;
            employee.LastName = input.LastName;
            employee.SubareaId = input.SubareaId;

            await _employeeRepository.Update(employee);

            _outputPort.Ok(employee);
        }
    }
}
