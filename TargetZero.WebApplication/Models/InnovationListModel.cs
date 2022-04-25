using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TargetZero.WebApplication.Models
{
    public class InnovationListModel
    {
        public IEnumerable<InnovationItemModel> Innovations { get; set; }
        public PageModel PageModel { get; set; }
        public InnovationSortModel SortModel { get; set; }
        public InnovationFilterModel FilterModel { get; set; }
        public int Count { get; set; }
        public bool CanGetSecurityReport { get; set; }

        public InnovationTasks InnovationTasks { get; set; }

    }
}
