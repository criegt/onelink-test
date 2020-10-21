using System.Collections.Generic;
using OneLinkTest.Domain.Employees;

namespace OneLinkTest.Application.UseCases.Employees.SearchEmployees
{
    public class SearchEmployeesPresenter : IOutputPort
    {
        public IReadOnlyList<Employee>? Employees { get; private set; }

        public void Ok(IReadOnlyList<Employee> employees)
        {
            Employees = employees;
        }
    }
}
