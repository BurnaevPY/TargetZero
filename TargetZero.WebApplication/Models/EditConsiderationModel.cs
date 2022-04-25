using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TargetZero.Domain;

namespace TargetZero.WebApplication.Models
{
    public class EditConsiderationModel
    {
        public int Id { get; set; }

        [FromRoute(Name = "innovationId")]
        public int InnovationId { get; set; }

        [Display(Name = "Пояснение")]
        public string Content { get; set; }

        //[Display(Name = "Статус рассмотрения")]
        //public int InnovationStatusId { get; set; }

        [Display(Name = "Результат рассмотрения")]
        public int ConsiderationResultId { get; set; }

        public InnovationCardModel Innovation { get; set; }

        public string ConsiderationGroupName { get; set; }

        public string ReturnUrl { get; set; }

        public IEnumerable<ConsiderationModel> Considerations { get; set; }


    }
}
