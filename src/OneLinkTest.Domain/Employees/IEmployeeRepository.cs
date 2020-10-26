using System.Collections.Generic;
using System.Threading.Tasks;

namespace OneLinkTest.Domain.Employees
{
    public interface IEmployeeRepository
    {
        Task Add(Employee employee);

        Task Remove(Employee employee);

        Task Update(Employee employee);

        Task<Employee> Find(long employeeId);

        Task<Employee> Find(long document, DocumentType documentType);

        Task<(int, IReadOnlyList<Employee>)> GetEmployeesWithSubarea(int pageIndex, int pageSize, string searchTerms);
    }
}
