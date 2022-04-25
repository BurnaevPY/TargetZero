using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TargetZero.Domain;

namespace TargetZero.WebApplication.Models
{
    public class ReportInnovationItemModel
    {
        /// <summary>
        /// Код предложения
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Автор предложения
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Дата предложения
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// Краткое описание предложения
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Как есть
        /// </summary>
        public string CurrentState { get; set; }

        /// <summary>
        /// Как будет
        /// </summary>
        public string TargetState { get; set; }

        /// <summary>
        /// Обоснование
        /// </summary>
        public string Reason { get; set; }

        /// <summary>
        /// Категория предложения
        /// </summary>
        public string CategoryName { get; set; }

        /// <summary>
        /// Категория предложения
        /// </summary>
        public string FilialName { get; set; }

        /// <summary>
        /// Статус предложение
        /// </summary>
        public string InnovationStatusDescription { get; set; }

        /// <summary>
        /// Количество рассмотрений
        /// </summary>
        public int ConsiderationCount { get; set; }

        /// <summary>
        /// Количество резолюций
        /// </summary>
        public int ResolutionCount { get; set; }

        /// <summary>
        /// Дата исполнения последней резолюции
        /// </summary>
        public DateTime? LastResolutionCreateTime { get; set; }

        /// <summary>
        /// Содержимое последней резолюции
        /// </summary>
        public string LastResolutionContent { get; set; }


        /// <summary>
        /// Содержимое рассмотрения группы 1
        /// </summary>
        public string ConsiderationGroup1 { get; set; }

        /// <summary>
        /// Содержимое рассмотрения группы 2
        /// </summary>
        public string ConsiderationGroup2 { get; set; }

        /// <summary>
        /// Содержимое рассмотрения группы 3
        /// </summary>
        public string ConsiderationGroup3 { get; set; }

        /// <summary>
        /// Содержимое рассмотрения группы 4
        /// </summary>
        public string ConsiderationGroup4 { get; set; }

        /// <summary>
        /// Содержимое рассмотрения группы 5
        /// </summary>
        public string ConsiderationGroup5 { get; set; }

        /// <summary>
        /// Содержимое рассмотрения группы 6
        /// </summary>
        public string ConsiderationGroup6 { get; set; }

        /// <summary>
        /// Содержимое рассмотрения группы 7
        /// </summary>
        public string ConsiderationGroup7 { get; set; }


    }
}
