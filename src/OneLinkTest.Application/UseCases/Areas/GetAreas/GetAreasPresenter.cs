using System.Collections.Generic;
using OneLinkTest.Domain.Areas;

namespace OneLinkTest.Application.UseCases.Areas.GetAreas
{
    public class GetAreasPresenter : IOutputPort
    {
        public IReadOnlyList<Area>? Areas { get; private set; }

        public void Ok(IReadOnlyList<Area> areas) => Areas = areas;
    }
}
