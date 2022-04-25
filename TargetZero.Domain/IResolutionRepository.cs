using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TargetZero.Domain.Abstractions;

namespace TargetZero.Domain
{
    public interface IResolutionRepository : IRepository<Resolution>
    {
        public Task<Resolution> GetAsync(int id);
        public Task<IEnumerable<Resolution>> GetInnovationResolutionsAsync(int innovationId);
        void Insert(Resolution resolution);
        Resolution Update(Resolution resolution);

    }
}
