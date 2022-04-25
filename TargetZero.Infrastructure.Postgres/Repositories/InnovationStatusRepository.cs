using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TargetZero.Domain;
using TargetZero.Domain.Abstractions;

namespace TargetZero.Infrastructure.Postgres.Repositories
{
    public class InnovationStatusRepository : IInnovationStatusRepository
    {
        private readonly TargetZeroContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public InnovationStatusRepository(TargetZeroContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<InnovationStatus>> GetAsync()
        {

            return await _context.InnovationStatuses.ToListAsync();

        }

        public async Task<InnovationStatus> GetAsync(int id)
        {
            return await _context.InnovationStatuses.FindAsync(id);
        }

    }
}
