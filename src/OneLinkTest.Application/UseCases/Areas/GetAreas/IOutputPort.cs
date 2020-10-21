using System.Collections.Generic;
using OneLinkTest.Domain.Areas;

namespace OneLinkTest.Application.UseCases.Areas.GetAreas
{
    public interface IOutputPort
    {
        void Ok(IReadOnlyList<Area> areas);
    }
}
