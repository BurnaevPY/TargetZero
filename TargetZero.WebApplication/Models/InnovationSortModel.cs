using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TargetZero.WebApplication.Models
{
    public class InnovationSortModel
    {
        public InnovationSortState IdSort { get; private set; }
        public InnovationSortState CreateTimeSort { get; private set; }
        public InnovationSortState TotalSort { get; private set; }
        public InnovationSortState Current { get; private set; }

        public InnovationSortModel(InnovationSortState sortOrder)
        {
            IdSort = sortOrder == InnovationSortState.IdAsc ? InnovationSortState.IdDesc : InnovationSortState.IdAsc;
            CreateTimeSort = sortOrder == InnovationSortState.CreateTimeAsc ? InnovationSortState.CreateTimeDesc : InnovationSortState.CreateTimeAsc;
            TotalSort = sortOrder == InnovationSortState.TotalAsc ? InnovationSortState.TotalDesc : InnovationSortState.TotalAsc;
            Current = sortOrder;
        }
    }
}
