using OneLinkTest.Domain.Employees;

namespace OneLinkTest.Application.UseCases.Employees.GetEmployee
{
    public class GetEmployeePresenter : IOutputPort
    {
        public bool NotFoundOutput { get; private set; }
        public Employee Employee { get; private set; }

        public void NotFound() => NotFoundOutput = true;

        public void Ok(Employee employee) => Employee = employee;
    }
}
