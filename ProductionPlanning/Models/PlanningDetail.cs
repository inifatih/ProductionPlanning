using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductionPlanning.Models
{
    public class PlanningDetail
    {
        [Key]
        public int DetailId { get; set; }

        [ForeignKey("Planning")]
        public int PlanningId { get; set; }
        public string DayName { get; set; }
        public int OriginalValue { get; set; }
        public int AdjustedValue { get; set; }
        public Planning Planning { get; set; }
    }
}
