using OneLinkTest.Domain.Employees;

namespace OneLinkTest.Application.UseCases.Employees.UpdateEmployee
{
    public interface IOutputPort
    {
        void NotFound();

        void Invalid();

        void Ok(Employee employee);
    }
}
