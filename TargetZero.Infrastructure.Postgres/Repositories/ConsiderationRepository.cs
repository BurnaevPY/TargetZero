using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TargetZero.Domain;
using TargetZero.Domain.Abstractions;

namespace TargetZero.Infrastructure.Postgres.Repositories
{
    public class ConsiderationRepository : IConsiderationRepository
    {
        private readonly TargetZeroContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public ConsiderationRepository(TargetZeroContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Consideration>> GetInnovationConsiderationsAsync(int innovationId)
        {
            return await _context.Considerations
                //.Include(x => x.InnovationStatus)
                .Include(x => x.ConsiderationResult)
                .Include(x => x.ConsiderationGroup)
                .Where(x => x.InnovationId == innovationId)
                .OrderByDescending(x => x.Id)
                .ToListAsync();
        }

        public async Task<Consideration> GetAsync(int innovationId, int consideratonGroupId)
        {
            return await _context.Considerations
                //.Include(x => x.InnovationStatus)
                .Include(x => x.ConsiderationResult)
                .Include(x => x.ConsiderationGroup)
                .Where(x => x.InnovationId == innovationId && x.ConsiderationGroup.Id == consideratonGroupId)
                .FirstOrDefaultAsync();
        }


        public void Insert(Consideration consideration)
        {
            _context.Considerations.Add(consideration);
        }

        public Consideration Update(Consideration consideration)
        {
            return consideration;
        }


    }
}
