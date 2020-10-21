using System.Collections.Generic;
using OneLinkTest.Domain.Employees;

namespace OneLinkTest.Application.UseCases.Employees.SearchEmployees
{
    public interface IOutputPort
    {
        void Ok(IReadOnlyList<Employee> employees);
    }
}
