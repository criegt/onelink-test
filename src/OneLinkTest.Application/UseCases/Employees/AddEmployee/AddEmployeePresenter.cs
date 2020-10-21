using OneLinkTest.Domain.Employees;

namespace OneLinkTest.Application.UseCases.Employees.AddEmployee
{
    public class AddEmployeePresenter : IOutputPort
    {
        public Employee? Employee { get; private set; }
        public bool ConflictOutput { get; private set; }
        public bool InvalidOutput { get; private set; }

        public void Conflict() => ConflictOutput = true;

        public void Invalid() => InvalidOutput = true;

        public void Ok(Employee employee) => Employee = employee;
    }
}
