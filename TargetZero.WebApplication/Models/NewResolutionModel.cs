using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TargetZero.WebApplication.Models
{
    public class NewResolutionModel
    {
        public int InnovationId { get; set; }

        [Display(Name = "Содержимое резолюции")]
        public string Content { get; set; }

        [Display(Name = "Срок исполнения")]
        public DateTime? ExcecutionTime { get; set; }

        public IEnumerable<ResolutionHistoryModel> History { get; set; }

        public InnovationCardModel Innovation { get; set; }

        public IEnumerable<ConsiderationModel> Considerations { get; set; }

        public string ReturnUrl { get; set; }

    }
}
