using System.Threading.Tasks;
using OneLinkTest.Domain.Areas;

namespace OneLinkTest.Application.UseCases.Areas.GetAreas
{
    public class GetAreasUseCase : IGetAreasUseCase
    {
        private readonly IAreaRepository _areaRepository;
        private IOutputPort _outputPort;

        public GetAreasUseCase(IAreaRepository areaRepository)
        {
            _areaRepository = areaRepository;
            _outputPort = new GetAreasPresenter();
        }

        public void SetOutputPort(IOutputPort outputPort)
        {
            _outputPort = outputPort;
        }

        public async Task Execute()
        {
            var areas = await _areaRepository.GetAreasWithSubareas();
            _outputPort.Ok(areas);
        }
    }
}
