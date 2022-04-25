using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TargetZero.Domain;

namespace TargetZero.WebApplication.Models
{
    public class InnovationCardModel
    {
        /// <summary>
        /// Код предложения
        /// </summary>
        [Display(Name ="Номер")]
        public int Id { get; set; }

        /// <summary>
        /// Дата предложения
        /// </summary>
        [Display(Name = "Дата")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// Автор предложения
        /// </summary>
        [Display(Name = "Автор")]
        public string Author { get; set; }

        /// <summary>
        /// Краткое описание предложения
        /// </summary>
        [Display(Name = "Краткое описание")]
        public string Description { get; set; }

        /// <summary>
        /// Как есть
        /// </summary>
        [Display(Name = "Текущее состояние")]
        public string CurrentState { get; set; }

        /// <summary>
        /// Как будет
        /// </summary>
        [Display(Name = "Целевое состояние")]
        public string TargetState { get; set; }

        /// <summary>
        /// Обоснование
        /// </summary>
        [Display(Name = "Обоснование")]
        public string Reason { get; set; }

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

        [Display(Name ="Статус")]
        public string InnovationStatusDescription { get; set; }


        public static InnovationCardModel ToViewModel(Innovation innovation)
        {
            return new InnovationCardModel
            {
                Id = innovation.Id,
                Author = innovation.Author,
                CategoryName = innovation.Category.Name,
                FilialName = innovation.Filial.Name,
                InnovationStatusDescription = innovation.InnovationStatus.Description,
                CreateTime = innovation.CreateTime,
                CurrentState = innovation.CurrentState,
                Description = innovation.Description,
                Reason = innovation.Reason,
                TargetState = innovation.TargetState
            };
        }
    }
}
