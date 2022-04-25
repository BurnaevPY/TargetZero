using System.Collections.Generic;
using System.Threading.Tasks;
using TargetZero.Domain.Abstractions;

namespace TargetZero.Domain
{
    public interface IConsiderationGroupRepository : IRepository<ConsiderationGroup>
    {
        Task<IEnumerable<ConsiderationGroup>> GetAsync();
        Task<ConsiderationGroup> GetAsync(int id);
    }
}
