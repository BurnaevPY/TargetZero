using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TargetZero.Domain
{
    /// <summary>
    /// Рацпредложение
    /// </summary>
    public class Innovation
    {
        /// <summary>
        /// Код предложения
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Дата предложения
        /// </summary>
        public DateTime CreateTime { get; private set; }

        /// <summary>
        /// Автор предложения
        /// </summary>
        public string Author { get; private set; }

        /// <summary>
        /// Краткое описание предложения
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// Как есть
        /// </summary>
        public string CurrentState { get; private set; }

        /// <summary>
        /// Как будет
        /// </summary>
        public string TargetState { get; private set; }

        /// <summary>
        /// Обоснование
        /// </summary>
        public string Reason { get; private set; }

        /// <summary>
        /// Категория предложения
        /// </summary>
        public Category Category { get; private set; }

        /// <summary>
        /// Актуальность предложения
        /// </summary>
        public bool IsActual { get; private set; } = true;

        /// <summary>
        /// Филиал 
        /// </summary>
        public Filial Filial { get; private set; }

        /// <summary>
        /// Финальный статус предложения
        /// </summary>
        public InnovationStatus InnovationStatus { get; private set; }



        public static Innovation Create(
            Category category, Filial filial, InnovationStatus innovationStatus,
            String author, string description, string currentState, string targetState, string reason)
        {
            return new Innovation
            {
                InnovationStatus = innovationStatus,
                Category = category,
                Filial = filial,
                CreateTime = DateTime.Now,
                Author = author.ToLower(),
                Description = description,
                CurrentState = currentState,
                TargetState = targetState,
                Reason = reason,
                IsActual = true
            };
        }

        public void Update(
            Category category, Filial filial, 
            string description, string currentState, string targetState, string reason)
        {
            Category = category;
            Filial = filial;
            CurrentState = currentState;
            Description = description;
            TargetState = targetState;
            Reason = reason;
        }

        public void SetInnovationStatus(InnovationStatus innovationStatus)
        {
            InnovationStatus = innovationStatus;
        }

        public void MarkAsDeleted()
        {
            IsActual = false;
        }
    }
}
