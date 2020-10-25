using OneLinkTest.Domain.Employees;

namespace OneLinkTest.Application.UseCases.Employees.GetEmployee
{
    public interface IOutputPort
    {
        void NotFound();

        void Ok(Employee employee);
    }
}
