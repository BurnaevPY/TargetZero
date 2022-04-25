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
    public class ConsiderationGroupRepository : IConsiderationGroupRepository
    {
        private readonly TargetZeroContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public ConsiderationGroupRepository(TargetZeroContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ConsiderationGroup>> GetAsync()
        {
            return await _context.ConsiderationGroups.ToListAsync();

        }

        public async Task<ConsiderationGroup> GetAsync(int id)
        {
            return await _context.ConsiderationGroups.FindAsync(id);
        }

    }
}
