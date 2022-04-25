using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TargetZero.Domain.Abstractions;

namespace TargetZero.Domain
{
    /// <summary>
    /// Статус расмотрения предложения
    /// </summary>
    public class InnovationStatus : Enumeration
    {
        public static InnovationStatus Consideration = new(1, nameof(Consideration), "Рассмотрение");
        public static InnovationStatus Accepted = new(2, nameof(Accepted), "Принято");
        public static InnovationStatus Rejected = new(3, nameof(Rejected), "Отклонено");
        public static InnovationStatus Clarification = new(4, nameof(Clarification), "Уточнение");
        public static InnovationStatus Rework = new(5, nameof(Rework), "Доработка");
        public static InnovationStatus Implemented = new(6, nameof(Implemented), "Реализовано");

        public InnovationStatus(int id, string name, string description)
            : base(id, name, description)
        {
        }
    }
}
