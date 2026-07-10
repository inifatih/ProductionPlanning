using Microsoft.EntityFrameworkCore;
using ProductionPlanning.Models;

namespace ProductionPlanning.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Planning> Plannings { get; set; }
        public DbSet<PlanningDetail> PlanningDetails { get; set; }
    }
}
