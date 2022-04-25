using System.ComponentModel.DataAnnotations;
using TargetZero.Domain;

namespace TargetZero.WebApplication.Models
{
    public class ConsiderationModel
    {
        public int Id { get; set; }

        [Display(Name = "Пояснение")]
        public string Content { get; set; }

        [Display(Name = "Группа рассмотрения")]
        public string ConsiderationGroupName { get; set; }

        //[Display(Name = "Статус рассмотрения")]
        //public string InnovationStatusName { get; set; }

        [Display(Name = "Результат рассмотрения")]
        public string ConsiderationResultName { get; set; }


        public static ConsiderationModel ToViewModel(Consideration consideration)
        {
            return new ConsiderationModel
            {
                Id = consideration.Id,
                Content = consideration.Content,
                ConsiderationResultName = consideration.ConsiderationResult.Description,
                ConsiderationGroupName = consideration.ConsiderationGroup.Description,
                //InnovationStatusName = consideration.InnovationStatus.Description
            };
        }


    }
}
