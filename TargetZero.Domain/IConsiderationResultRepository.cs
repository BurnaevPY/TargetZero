using System.Collections.Generic;
using System.Threading.Tasks;
using TargetZero.Domain.Abstractions;

namespace TargetZero.Domain
{
    public interface IConsiderationResultRepository : IRepository<ConsiderationResult>
    {
        Task<IEnumerable<ConsiderationResult>> GetAsync();
        Task<ConsiderationResult> GetAsync(int id);
    }
}
