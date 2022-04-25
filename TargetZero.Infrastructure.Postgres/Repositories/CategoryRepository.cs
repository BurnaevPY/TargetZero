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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly TargetZeroContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public CategoryRepository(TargetZeroContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetAsync()
        {

            return await _context.Categories.ToListAsync();

        }

        public async Task<Category> GetAsync(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

    }
}
