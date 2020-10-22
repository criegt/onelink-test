using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OneLinkTest.Application.UseCases.Areas.GetAreas;
using OneLinkTest.Domain.Areas;

namespace OneLinkTest.WebApi.Controllers.V1.Areas.GetAreas
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public sealed class AreasController : ControllerBase, IOutputPort
    {
        private IActionResult _viewModel;

        void IOutputPort.Ok(IReadOnlyList<Area> areas)
        {
            _viewModel = Ok(areas);
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromServices] IGetAreasUseCase useCase)
        {
            useCase.SetOutputPort(this);

            await useCase.Execute()
                .ConfigureAwait(false);

            return _viewModel;
        }
    }
}
