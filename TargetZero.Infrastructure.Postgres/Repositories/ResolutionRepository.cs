using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TargetZero.Domain;
using TargetZero.Domain.Abstractions;

namespace TargetZero.Infrastructure.Postgres.Repositories
{
    public class ResolutionRepository : IResolutionRepository
    {
        private readonly TargetZeroContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public ResolutionRepository(TargetZeroContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Resolution>> GetInnovationResolutionsAsync(int innovationId)
        {
            return await _context.Resolutions
                .Include(x => x.InnovationStatus)
                .Where(x => x.InnovationId == innovationId)
                .OrderByDescending(x => x.Id)
                .ToListAsync();

        }

        public async Task<Resolution> GetAsync(int id)
        {
            return await _context.Resolutions
                .Include(x => x.InnovationStatus)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }


        public void Insert(Resolution resolution)
        {
            _context.Resolutions.Add(resolution);
        }

        public Resolution Update(Resolution resolution)
        {
            return resolution;
        }


    }
}
