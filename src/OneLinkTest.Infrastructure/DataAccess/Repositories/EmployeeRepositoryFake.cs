using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OneLinkTest.Domain.Employees;

namespace OneLinkTest.Infrastructure.DataAccess.Repositories
{
    public class EmployeeRepositoryFake : IEmployeeRepository
    {
        private readonly OneLinkTestContextFake _context;

        public EmployeeRepositoryFake(OneLinkTestContextFake context)
        {
            _context = context;
        }

        public Task Add(Employee employee)
        {
            _context.Employees.Add(employee);
            return Task.CompletedTask;
        }

        public Task<Employee> Find(long employeeId)
        {
            return Task.FromResult(_context.Employees.FirstOrDefault(e => e.EmployeeId == employeeId));
        }

        public Task<Employee> Find(long document, DocumentType documentType)
        {
            return Task.FromResult(_context.Employees
                .FirstOrDefault(e => e.Document == document
                    && e.DocumentType == documentType));
        }

        public Task<IReadOnlyList<Employee>> GetEmployeesWithSubarea(int pageIndex, int pageSize, string searchTerms)
        {
            return Task.FromResult<IReadOnlyList<Employee>>(_context.Employees
                .Where(e => e.Document.ToString().Contains(searchTerms.ToLower())
                    || e.FirstName.Contains(searchTerms.ToLower())
                    || e.LastName.Contains(searchTerms.ToLower()))
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .ToList());
        }

        public Task Remove(Employee employee)
        {
            _context.Employees.Remove(employee);
            return Task.CompletedTask;
        }

        public Task Update(Employee employee)
        {
            return Task.CompletedTask;
        }
    }
}
