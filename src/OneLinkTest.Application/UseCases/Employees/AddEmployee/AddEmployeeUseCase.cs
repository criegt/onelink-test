using System.Threading.Tasks;
using OneLinkTest.Domain.Employees;

namespace OneLinkTest.Application.UseCases.Employees.AddEmployee
{
    public class AddEmployeeUseCase : IAddEmployeeUseCase
    {
        private IOutputPort _outputPort;
        private readonly IEmployeeRepository _employeeRepository;

        public AddEmployeeUseCase(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
            _outputPort = new AddEmployeePresenter();
        }

        public void SetOutputPort(IOutputPort outputPort) => _outputPort = outputPort;

        public async Task Execute(Input input)
        {
            var employee = new Employee
            {
                Document = input.Document,
                DocumentType = input.DocumentType,
                FirstName = input.FirstName,
                LastName = input.LastName,
                SubareaId = input.SubareaId
            };

            await _employeeRepository.Add(employee);

            _outputPort.Ok(employee);
        }
    }
}
