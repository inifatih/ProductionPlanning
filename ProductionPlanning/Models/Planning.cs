using System.ComponentModel.DataAnnotations;

namespace ProductionPlanning.Models
{
    public class Planning
    {
        [Key]
        public int PlanningId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public ICollection<PlanningDetail> Details { get; set; } = new List<PlanningDetail>();

    }
}
