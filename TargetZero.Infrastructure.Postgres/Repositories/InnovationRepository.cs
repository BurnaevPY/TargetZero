using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TargetZero.Domain;
using TargetZero.Domain.Abstractions;

namespace TargetZero.Infrastructure.Postgres.Repositories
{
    public class InnovationRepository : IInnovationRepository
    {
        private readonly TargetZeroContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public InnovationRepository(TargetZeroContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Innovation>> GetAsync()
        {
            return await _context.Innovations
                .Include(x => x.Category)
                .Include(x => x.Filial)
                .Include(x => x.InnovationStatus)
                .Where(x => x.IsActual)
                .OrderByDescending(x => x.Id)
                .ToListAsync();

        }

        public async Task<Innovation> GetAsync(int id)
        {
            return await _context.Innovations
                .Include(x => x.Category)
                .Include(x => x.Filial)
                .Include(x => x.InnovationStatus)
                .Where(x => x.Id == id && x.IsActual)
                .FirstOrDefaultAsync();
        }


        public void Insert(Innovation innovation)
        {
            _context.Innovations.Add(innovation);
        }

        public Innovation Update(Innovation innovation)
        {
            return innovation;
        }

        public Task<int> GetCountAsync()
        {
            return _context.Innovations.CountAsync();
        }
    }
}
