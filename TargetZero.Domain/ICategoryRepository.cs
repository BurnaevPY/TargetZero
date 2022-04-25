using System.Collections.Generic;
using System.Threading.Tasks;
using TargetZero.Domain.Abstractions;

namespace TargetZero.Domain
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<IEnumerable<Category>> GetAsync();
        Task<Category> GetAsync(int id);
    }
}
