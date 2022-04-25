using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TargetZero.Domain;

namespace TargetZero.WebApplication.Models
{
    public class InnovationItemModel
    {
        /// <summary>
        /// Код предложения
        /// </summary>
        [Display(Name ="Номер")]
        public int Id { get; set; }

        public string Author { get; set; }

        /// <summary>
        /// Дата предложения
        /// </summary>
        [Display(Name = "Дата")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// Краткое описание предложения
        /// </summary>
        [Display(Name = "Краткое описание")]
        public string Description { get; set; }

        /// <summary>
        /// Краткое описание предложения. Часть.
        /// </summary>
        [Display(Name = "Краткое описание")]
        public string DescriptionTruncated => TruncateWithEllipsis(Description);

        /// <summary>
        /// Как есть
        /// </summary>
        [Display(Name = "Текущее состояние")]
        public string CurrentState { get; set; }

        /// <summary>
        /// Как есть. Часть.
        /// </summary>
        [Display(Name = "Текущее состояние")]
        public string CurrentStateTrauncated => TruncateWithEllipsis(CurrentState);

        /// <summary>
        /// Как будет
        /// </summary>
        [Display(Name = "Целевое состояние")]
        public string TargetState { get; set; }

        /// <summary>
        /// Как будет. Часть
        /// </summary>
        [Display(Name = "Целевое состояние")]
        public string TargetStateTruncated => TruncateWithEllipsis(TargetState);

        /// <summary>
        /// Обоснование
        /// </summary>
        [Display(Name = "Обоснование")]
        public string Reason { get; set; }

        /// <summary>
        /// Обоснование. Часть
        /// </summary>
        [Display(Name = "Обоснование")]
        public string ReasonTruncated => TruncateWithEllipsis(Reason);

        /// <summary>
        /// Категория предложения
        /// </summary>
        [Display(Name = "Категория")]
        public string CategoryName { get; set; }

        /// <summary>
        /// Категория предложения
        /// </summary>
        [Display(Name = "Подразделение")]
        public string FilialName { get; set; }

        public int InnovationStatusId { get; set; }

        [Display(Name ="Статус")]
        public string InnovationStatusDescription { get; set; }

        [Display(Name = "Рассмотрений")]
        public int ConsiderationCount { get; set; }

        [Display(Name = "Резолюций")]
        public int ResolutionCount { get; set; }

        public bool CanChangeInnovation { get; set; }
        public bool CanWriteResolution { get; set; }
        public bool CanWriteConsideration { get; set; }
             

        private string TruncateWithEllipsis(string source)
        {
            return source.Length < Options.InnovationListColumnLetterCount ? 
                source : 
                $"{source.Substring(0, Options.InnovationListColumnLetterCount)}...";
        }
    }
}
