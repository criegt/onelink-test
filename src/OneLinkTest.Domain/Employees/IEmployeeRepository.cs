using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OneLinkTest.Domain.Employees
{
    public interface IEmployeeRepository
    {
        Task Add(Employee employee);

        Task Remove(Employee employee);

        Task Update(Employee employee);

        Task<Employee> Find(EmployeeId employeeId);

        Task<IReadOnlyList<Employee>> GetEmployees(string searchTerms);

        Task<IReadOnlyList<Employee>> GetEmployeesWithSubarea(int pageIndex, int pageSize);
    }
}
