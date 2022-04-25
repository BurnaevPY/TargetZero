using TargetZero.Domain.Abstractions;

namespace TargetZero.Domain
{
    /// <summary>
    /// Группы рассмотрения
    /// </summary>
    public class ConsiderationGroup : Enumeration
    {
        //public static ConsiderationGroup DecisionGroup = new(1, nameof(DecisionGroup), "Группа принятия решений");
        public static ConsiderationGroup Group1 = new(1, nameof(Group1), "Группа рассмотрения 1");
        public static ConsiderationGroup Group2 = new(2, nameof(Group2), "Группа рассмотрения 2");
        public static ConsiderationGroup Group3 = new(3, nameof(Group3), "Группа рассмотрения 3");
        public static ConsiderationGroup Group4 = new(4, nameof(Group4), "Группа рассмотрения 4");
        public static ConsiderationGroup Group5 = new(5, nameof(Group5), "Группа рассмотрения 5");
        public static ConsiderationGroup Group6 = new(6, nameof(Group6), "Группа рассмотрения 6");
        public static ConsiderationGroup Group7 = new(7, nameof(Group7), "Группа рассмотрения 7");
        public static ConsiderationGroup GrnuGroup = new(8, nameof(GrnuGroup), "Группа рассмотрения ГРНУ");
        public static ConsiderationGroup RrnuGroup = new(9, nameof(RrnuGroup), "Группа рассмотрения РРНУ");
        public static ConsiderationGroup MrnuGroup = new(10, nameof(MrnuGroup), "Группа рассмотрения МРНУ");
        public static ConsiderationGroup BptoGroup = new(11, nameof(BptoGroup), "Группа рассмотрения БПТОиКО");
        public static ConsiderationGroup TnmGroup = new(12, nameof(TnmGroup), "Группа рассмотрения ТНМ");
        public static ConsiderationGroup VrnpuGroup = new(13, nameof(VrnpuGroup), "Группа рассмотрения ВРНПУ");
        public static ConsiderationGroup TspaGroup = new(14, nameof(TspaGroup), "Группа рассмотрения ЦПА");

        public ConsiderationGroup(int id, string name, string description)
            : base(id, name, description)
        {
        }
    }
}
