using System.Threading.Tasks;

namespace OneLinkTest.Application.UseCases.Employees.AddEmployee
{
    public interface IAddEmployeeUseCase
    {
        void SetOutputPort(IOutputPort outputPort);
        Task Execute(Input input);
    }
}
