using System.Threading.Tasks;
using OneLinkTest.Domain.Employees;

namespace OneLinkTest.Application.UseCases.Employees.SearchEmployees
{
    public class SearchEmployeesUseCase
    {
        private readonly IEmployeeRepository _employeeRepository;
        private IOutputPort _outputPort;

        public SearchEmployeesUseCase(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
            _outputPort = new SearchEmployeesPresenter();
        }

        public void SetOutputPort(IOutputPort outputPort)
        {
            _outputPort = outputPort;
        }

        public async Task Execute(Input input)
        {
            var employees = await _employeeRepository.GetEmployees(input.SearchTerms);
            _outputPort.Ok(employees);
        }
    }
}
