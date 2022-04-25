using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TargetZero.Domain;

namespace TargetZero.WebApplication.Models
{
    public class ResolutionHistoryModel
    {
        public int Id { get; set; }
        public string Author { get; set; }

        [Display(Name = "Дата создания")]
        public DateTime CreateTime { get; set; }

        [Display(Name = "Статус")]
        public string InnovationStatusDescription { get; set; }

        [Display(Name = "Срок исполнения")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime? ExecutionTime { get; set; }

        [Display(Name = "Содержимое резолюции")]
        public string Content { get; set; }

        public static ResolutionHistoryModel ToViewModel(Resolution resolution)
        {
            return new ResolutionHistoryModel
            {
                Id = resolution.Id,
                Author = resolution.Author,
                ExecutionTime = resolution.ExecutionTime,
                Content = resolution.Content,
                CreateTime = resolution.CreateTime,
                InnovationStatusDescription = resolution.InnovationStatus.Description
            };
        }

    }
}
