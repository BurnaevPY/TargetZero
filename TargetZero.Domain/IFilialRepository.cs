using System.Collections.Generic;
using System.Threading.Tasks;
using TargetZero.Domain.Abstractions;

namespace TargetZero.Domain
{
    public interface IFilialRepository : IRepository<Filial>
    {
        Task<IEnumerable<Filial>> GetAsync();
        Task<Filial> GetAsync(int id);
    }
}
