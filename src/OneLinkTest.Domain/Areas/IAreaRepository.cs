using System.Collections.Generic;
using System.Threading.Tasks;

namespace OneLinkTest.Domain.Areas
{
    public interface IAreaRepository
    {
        Task<IReadOnlyList<Area>> GetAreasWithSubareas();
    }
}
