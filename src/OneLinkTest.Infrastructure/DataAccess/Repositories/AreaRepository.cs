using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OneLinkTest.Domain.Areas;

namespace OneLinkTest.Infrastructure.DataAccess.Repositories
{
    public class AreaRepository : IAreaRepository
    {
        private readonly OneLinkTestContext _context;

        public AreaRepository(OneLinkTestContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<Area>> GetAreasWithSubareas()
        {
            return await _context.Areas.Include(a => a.Subareas)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
