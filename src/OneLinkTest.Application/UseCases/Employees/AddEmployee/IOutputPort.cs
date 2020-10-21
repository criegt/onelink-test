using OneLinkTest.Domain.Employees;

namespace OneLinkTest.Application.UseCases.Employees.AddEmployee
{
    public interface IOutputPort
    {
        void Conflict();

        void Invalid();

        void Ok(Employee employee);
    }
}
