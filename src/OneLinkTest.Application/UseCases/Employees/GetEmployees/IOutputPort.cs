using System.Collections.Generic;
using OneLinkTest.Domain.Employees;

namespace OneLinkTest.Application.UseCases.Employees.GetEmployees
{
    public interface IOutputPort
    {
        void Ok(int totalCount, IReadOnlyList<Employee> employees);
    }
}
