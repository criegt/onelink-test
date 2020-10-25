using OneLinkTest.Domain.Employees;

namespace OneLinkTest.Application.UseCases.Employees.UpdateEmployee
{
    public class UpdateEmployeePresenter : IOutputPort
    {
        public Employee Employee { get; private set; }
        public bool NotFoundOutput { get; private set; }
        public bool InvalidOutput { get; private set; }

        public void NotFound() => NotFoundOutput = true;

        public void Invalid() => InvalidOutput = true;

        public void Ok(Employee employee) => Employee = employee;
    }
}
