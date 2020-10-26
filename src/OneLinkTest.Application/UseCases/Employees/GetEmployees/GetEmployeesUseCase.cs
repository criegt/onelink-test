using System.Threading.Tasks;
using OneLinkTest.Domain.Employees;

namespace OneLinkTest.Application.UseCases.Employees.GetEmployees
{
    public class GetEmployeesUseCase : IGetEmployeesUseCase
    {
        private readonly IEmployeeRepository _employeeRepository;
        private IOutputPort _outputPort;

        public GetEmployeesUseCase(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
            _outputPort = new GetEmployeesPresenter();
        }

        public void SetOutputPort(IOutputPort outputPort)
        {
            _outputPort = outputPort;
        }

        public async Task Execute(Input input)
        {
            var (count, employees) = await _employeeRepository.GetEmployeesWithSubarea(input.PageIndex, input.PageSize, input.SearchTerms);
            _outputPort.Ok(count, employees);
        }
    }
}
