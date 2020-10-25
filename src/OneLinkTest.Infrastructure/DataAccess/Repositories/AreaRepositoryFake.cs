using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OneLinkTest.Domain.Areas;

namespace OneLinkTest.Infrastructure.DataAccess.Repositories
{
    public class AreaRepositoryFake : IAreaRepository
    {
        private readonly OneLinkTestContextFake _context;

        public AreaRepositoryFake(OneLinkTestContextFake context)
        {
            _context = context;
        }

        public Task<IReadOnlyList<Area>> GetAreasWithSubareas()
        {
            return Task.FromResult<IReadOnlyList<Area>>(_context.Areas.ToList());
        }
    }
}
