using System.Threading.Tasks;

namespace OneLinkTest.Application.UseCases.Employees.UpdateEmployee
{
    public interface IUpdateEmployeeUseCase
    {
        void SetOutputPort(IOutputPort outputPort);
        Task Execute(Input input);
    }
}
