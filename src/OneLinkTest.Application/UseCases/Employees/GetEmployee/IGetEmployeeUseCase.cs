using System.Threading.Tasks;

namespace OneLinkTest.Application.UseCases.Employees.GetEmployee
{
    public interface IGetEmployeeUseCase
    {
        Task Execute(long employeeId);
        void SetOutputPort(IOutputPort outputPort);
    }
}