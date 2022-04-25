using System;

namespace TargetZero.Domain
{
    /// <summary>
    /// Резолюция 
    /// </summary>
    public class Resolution
    {
        /// <summary>
        /// Идентифкатор резолюции
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Автор резолюции
        /// </summary>
        public string Author { get; private set; }

        /// <summary>
        /// Дата создания резолюции
        /// </summary>
        public DateTime CreateTime { get; private set; }

        /// <summary>
        /// Содержимое резолюции
        /// </summary>
        public string Content { get; private set; }

        /// <summary>
        /// Время исполнения
        /// </summary>
        public DateTime? ExecutionTime { get; private set; }

        /// <summary>
        /// Статус резолюции
        /// </summary>
        public InnovationStatus InnovationStatus { get; private set; }

        /// <summary>
        /// ссылка на предложение
        /// </summary>
        public int InnovationId { get; private set; }
             

        public static Resolution Create(int innovationId, InnovationStatus innovationStatus, string author, DateTime? executionTime, string content)
        {
            return new Resolution
            {
                Author = author,
                Content = content,
                CreateTime = DateTime.Now,
                ExecutionTime = executionTime,
                InnovationId = innovationId,
                InnovationStatus = innovationStatus
            };
        }

    }
}
