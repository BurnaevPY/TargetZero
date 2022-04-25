using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TargetZero.Domain.Abstractions;

namespace TargetZero.Domain
{
    public interface IInnovationRepository : IRepository<Innovation>
    {
        public Task<Innovation> GetAsync(int id);
        public Task<IEnumerable<Innovation>> GetAsync();
        void Insert(Innovation innovation);
        Innovation Update(Innovation innovation);
        Task<int> GetCountAsync();

    }
}
