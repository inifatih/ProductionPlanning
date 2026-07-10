using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProductionPlanning.Models;
using ProductionPlanning.Data;
using Microsoft.EntityFrameworkCore;

namespace ProductionPlanning.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new PlanningInput());
        }

        [HttpPost]
        public IActionResult Generate(PlanningInput model)
        {
            var days = new List<(string Day, int Value)>
            {
                ("Senin", model.Monday),
                ("Selasa", model.Tuesday),
                ("Rabu", model.Wednesday),
                ("Kamis", model.Thursday),
                ("Jumat", model.Friday),
                ("Sabtu", model.Saturday),
                ("Minggu", model.Sunday)
            };

            var activeDays = days.Where(x => x.Value > 0);
            int total = activeDays.Sum(x => x.Value);
            int dayCount = activeDays.Count();
            int average = total / dayCount;
            int remainder = total % dayCount;

            var result = activeDays.OrderByDescending(x => x.Value).ToList();

            Dictionary<string, int> balanced = new();

            foreach (var item in activeDays)
                balanced[item.Day] = average;

            for (int i = 0; i < remainder; i++)
            {
                balanced[result[i].Day]++;
            }

            foreach (var item in days.Where(x => x.Value == 0))
            {
                balanced[item.Day] = 0;
            }

            var planning = new Planning();

            _context.Plannings.Add(planning);

            _context.SaveChanges();

            foreach (var item in days)
            {
                _context.PlanningDetails.Add(new PlanningDetail
                {
                    PlanningId = planning.PlanningId,
                    DayName = item.Day,
                    OriginalValue = item.Value,
                    AdjustedValue = balanced[item.Day]
                });
            }

            _context.SaveChanges();

            ViewBag.Result = balanced;

            return View("Index", model);
        }

        public IActionResult History()
        {
            var data = _context.Plannings
                .Include(x => x.Details)
                .OrderByDescending(x => x.CreatedDate)
                .ToList();

            return View(data);
        }
    }
}
