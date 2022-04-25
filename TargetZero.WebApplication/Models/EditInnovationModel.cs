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
    public class EditInnovationModel
    {
        /// <summary>
        /// Код предложения
        /// </summary>
        [FromRoute(Name = "id")]
        public int Id { get; set; }

        /// <summary>
        /// Дата предложения
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// Краткое описание предложения
        /// </summary>
        [Display(Name = "Краткое описание")]
        [Required]
        public string Description { get; set; }

        /// <summary>
        /// Как есть
        /// </summary>
        [Display(Name = "Текущее состояние")]
        [Required]
        public string CurrentState { get; set; }

        /// <summary>
        /// Как будет
        /// </summary>
        [Display(Name = "Целевое состояние")]
        [Required]
        public string TargetState { get; set; }

        /// <summary>
        /// Обоснование
        /// </summary>
        [Display(Name = "Обоснование")]
        [Required]
        public string Reason { get; set; }

        /// <summary>
        /// Категория предложения
        /// </summary>
        [Display(Name = "Категория")]
        [Required]
        public int CategoryId { get; set; }

        /// <summary>
        /// Категория предложения
        /// </summary>
        [Display(Name = "Подразделение")]
        [Required]
        public int FilialId { get; set; }

        /// <summary>
        /// Статус предложения
        /// </summary>
        public string InnovationStatusDescription { get; set; }

        public string ReturnUrl { get; set; }

        public bool CanSendToConsideration { get; set; }

        public static EditInnovationModel ToViewModel(Innovation innovation, string returnUrl)
        {
            return new EditInnovationModel
            {
                Id = innovation.Id,
                CategoryId = innovation.Category.Id,
                FilialId = innovation.Filial.Id,
                CreateTime = innovation.CreateTime,
                CurrentState = innovation.CurrentState,
                Description = innovation.Description,
                Reason = innovation.Reason,
                TargetState = innovation.TargetState,
                InnovationStatusDescription = innovation.InnovationStatus.Description,
                ReturnUrl = returnUrl
            };
        }
    }
}
