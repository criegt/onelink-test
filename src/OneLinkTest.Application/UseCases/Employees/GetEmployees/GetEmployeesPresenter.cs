using System.Collections.Generic;
using OneLinkTest.Domain.Employees;

namespace OneLinkTest.Application.UseCases.Employees.GetEmployees
{
    public class GetEmployeesPresenter : IOutputPort
    {
        public IReadOnlyList<Employee>? Employees { get; private set; }

        public void Ok(IReadOnlyList<Employee> employees)
        {
            Employees = employees;
        }
    }
}
