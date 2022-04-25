using System.Collections.Generic;
using System.Threading.Tasks;
using TargetZero.Domain.Abstractions;

namespace TargetZero.Domain
{
    public interface IInnovationStatusRepository : IRepository<InnovationStatus>
    {
        Task<IEnumerable<InnovationStatus>> GetAsync();
        Task<InnovationStatus> GetAsync(int id);
    }
}
