using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TargetZero.Domain;

namespace TargetZero.WebApplication.Models
{
    public class ViewInnovationModel
    {
        public InnovationCardModel Innovation { get; set; }

        public IEnumerable<ConsiderationModel> Considerations { get; set; }

        public IEnumerable<ResolutionHistoryModel> ResolutionHistory { get; set; }

    }
}
