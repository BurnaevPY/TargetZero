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
    public class ConsiderationResultRepository : IConsiderationResultRepository
    {
        private readonly TargetZeroContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public ConsiderationResultRepository(TargetZeroContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ConsiderationResult>> GetAsync()
        {

            return await _context.ConsiderationResults.ToListAsync();

        }

        public async Task<ConsiderationResult> GetAsync(int id)
        {
            return await _context.ConsiderationResults.FindAsync(id);
        }

    }
}
