using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TargetZero.Domain.Abstractions;

namespace TargetZero.Domain
{
    public interface IConsiderationRepository : IRepository<Consideration>
    {
        public Task<Consideration> GetAsync(int innovationId, int considerationGroupId);
        public Task<IEnumerable<Consideration>> GetInnovationConsiderationsAsync(int innovationId);
        void Insert(Consideration consideration);
        Consideration Update(Consideration consideration);
    }
}
