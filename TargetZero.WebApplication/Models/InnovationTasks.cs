using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using TargetZero.WebApplication.Extensions;

namespace TargetZero.WebApplication.Models
{
    public enum InnovationTasks
    {
        [Display(Name = "Не имеет значения")]
        None = 0,

        [Display(Name ="Мои рацпредложения")]
        MyInnovations,

    }

    public static class InnovationTasksExtension
    {
        public static IEnumerable<KeyValuePair<int, string>> GetAll()
        {
            return Enum.GetValues<InnovationTasks>()
                       .Select(e => new KeyValuePair<int, string>((int)e, e.GetDisplayName() ));
        }
    }





}
