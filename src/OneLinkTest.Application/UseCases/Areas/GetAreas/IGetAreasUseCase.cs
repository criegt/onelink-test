using System.Threading.Tasks;

namespace OneLinkTest.Application.UseCases.Areas.GetAreas
{
    public interface IGetAreasUseCase
    {
        Task Execute();
        void SetOutputPort(IOutputPort outputPort);
    }
}