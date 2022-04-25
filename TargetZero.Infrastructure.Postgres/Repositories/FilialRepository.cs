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
    public class FilialRepository : IFilialRepository
    {
        private readonly TargetZeroContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public FilialRepository(TargetZeroContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Filial>> GetAsync()
        {

            return await _context.Filials.ToListAsync();

        }

        public async Task<Filial> GetAsync(int id)
        {
            return await _context.Filials.FindAsync(id);
        }

    }
}
