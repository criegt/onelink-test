using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OneLinkTest.Domain.Employees;

namespace OneLinkTest.Infrastructure.DataAccess.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly OneLinkTestContext _context;

        public EmployeeRepository(OneLinkTestContext context)
        {
            _context = context;
        }

        public async Task Add(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
        }

        public async Task<Employee> Find(long employeeId)
        {
            return await _context.Employees.FindAsync(employeeId);
        }

        public async Task<Employee> Find(long document, DocumentType documentType)
        {
            return await _context.Employees
                .FirstOrDefaultAsync(e => e.Document == document
                    && e.DocumentType == documentType);
        }

        public async Task<(int, IReadOnlyList<Employee>)> GetEmployeesWithSubarea(int pageIndex, int pageSize, string searchTerms)
        {
            var query = _context.Employees
                .Where(e => e.Document.ToString().Contains(searchTerms.ToLower())
                    || e.FirstName.Contains(searchTerms.ToLower())
                    || e.LastName.Contains(searchTerms.ToLower()));
            var count = await query.CountAsync();

            return (count, await query.Skip(pageIndex * pageSize)
                .Take(pageSize)
                .AsNoTracking()
                .ToListAsync());
        }

        public async Task Remove(Employee employee)
        {
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Employee employee)
        {
            await _context.SaveChangesAsync();
        }
    }
}
