using System.Threading.Tasks;
using OneLinkTest.Domain.Employees;

namespace OneLinkTest.Application.UseCases.Employees.GetEmployee
{
    public class GetEmployeeUseCase : IGetEmployeeUseCase
    {
        private readonly IEmployeeRepository _employeeRepository;
        private IOutputPort _outputPort;

        public GetEmployeeUseCase(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
            _outputPort = new GetEmployeePresenter();
        }

        public void SetOutputPort(IOutputPort outputPort)
        {
            _outputPort = outputPort;
        }

        public async Task Execute(long employeeId)
        {
            var employee = await _employeeRepository.Find(employeeId);

            if (employee is null)
            {
                _outputPort.NotFound();
                return;
            }

            _outputPort.Ok(employee);
        }
    }
}
