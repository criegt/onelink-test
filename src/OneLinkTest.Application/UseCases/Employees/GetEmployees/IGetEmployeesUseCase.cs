using System.Threading.Tasks;

namespace OneLinkTest.Application.UseCases.Employees.GetEmployees
{
    public interface IGetEmployeesUseCase
    {
        Task Execute(Input input);
        void SetOutputPort(IOutputPort outputPort);
    }
}