using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TargetZero.Domain.Abstractions;

namespace TargetZero.Domain
{
    public class ConsiderationResult: Enumeration
    {
        public static ConsiderationResult OutOfResponsibility = new(1, nameof(Consideration), "Вне зоны ответственности");
        public static ConsiderationResult Accepted = new(2, nameof(Accepted), "Принято");
        public static ConsiderationResult Rejected = new(3, nameof(Rejected), "Отклонено");
        public static ConsiderationResult Clarification = new(4, nameof(Clarification), "Уточнение");
        public static ConsiderationResult Rework = new(5, nameof(Rework), "Доработка");

        public ConsiderationResult(int id, string name, string description)
            : base(id, name, description)
        {
        }
    }
}
