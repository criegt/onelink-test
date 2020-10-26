using System.Collections.Generic;
using OneLinkTest.Domain.Employees;

namespace OneLinkTest.Application.UseCases.Employees.GetEmployees
{
    public class GetEmployeesPresenter : IOutputPort
    {
        public int TotalCount { get; private set; }
        public IReadOnlyList<Employee> Employees { get; private set; }

        public void Ok(int totalCount, IReadOnlyList<Employee> employees)
        {
            TotalCount = totalCount;
            Employees = employees;
        }
    }
}
