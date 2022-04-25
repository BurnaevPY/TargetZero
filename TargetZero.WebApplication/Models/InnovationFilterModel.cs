using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using TargetZero.Domain;
using TargetZero.WebApplication.ModelFilters;

namespace TargetZero.WebApplication.Models
{
    public class InnovationFilterModel
    {
        public int? InnovationId { get; set; } 
        public SelectList Categories { get; set; }
        public int? CategoryId { get; set; }

        public SelectList Filials { get; set; }
        public int? FilialId { get; set; }

        public SelectList InnovationStatuses { get; set; }
        public int? InnovationStatusId { get; set; }

        public SelectList ConsiderationGroups { get; set; }
        public int? ConsiderationGroupId { get; set; }

        public SelectList NonConsiderationGroups { get; set; }
        public int? NonConsiderationGroupId { get; set; }

        public SelectList Resolutions { get; set; }
        public bool? HasResolution { get; set; }

        public  SelectList Considerations { get; set; }
        public bool? HasConsideration { get; set; }

        public int InnovationTask { get; set; }
        public SelectList InnovationTasks { get; set; }




        public InnovationFilterModel(
            int? innovationId,
            IEnumerable<ConsiderationGroup> considerationGroups, int? considerationGroupId, int? nonConsiderationGroupId,
            IEnumerable<Category> categories,  int? categoryId, 
            IEnumerable<Filial> filials, int? filialId,
            IEnumerable<InnovationStatus> innovationStatusess, int? innovationStatusId,
            InnovationTasks innovationTask,
            bool? hasResolution,
            bool? hasConsiderations)
        {
            InnovationId = innovationId;

            InnovationTask = (int)innovationTask;
            InnovationTasks = new SelectList(InnovationTasksExtension.GetAll(), "Key", "Value", InnovationTask);

            ConsiderationGroupId = considerationGroupId;
            ConsiderationGroups = new SelectList(considerationGroups, "Id", "Description", considerationGroupId);

            NonConsiderationGroupId = nonConsiderationGroupId;
            NonConsiderationGroups = new SelectList(considerationGroups, "Id", "Description", nonConsiderationGroupId);

            CategoryId = categoryId;
            Categories = new SelectList(categories, "Id", "Name", categoryId);

            FilialId = filialId;
            Filials = new SelectList(filials, "Id", "Name", filialId);

            InnovationStatusId = innovationStatusId;
            var fullInnovationStatuses = innovationStatusess.ToList();
            fullInnovationStatuses.Add(new InnovationStatus(InnovationStatusFilter.Reworked, "Reworked", "Доработанные"));

            InnovationStatuses = new SelectList(fullInnovationStatuses, "Id", "Description", innovationStatusId);


            var resolutions = new List<SelectListItem>
            {
                new SelectListItem("Есть", "true"),
                new SelectListItem("Нет", "false")
            };

            HasResolution = hasResolution;
            Resolutions = new SelectList(resolutions, "Value", "Text", hasResolution.ToString());

            var considerations = new List<SelectListItem>
            {
                new SelectListItem("Есть", "true"),
                new SelectListItem("Нет", "false")
            };

            HasConsideration = hasConsiderations;
            Considerations = new SelectList(considerations, "Value", "Text", hasConsiderations.ToString());

        }
    }
}
