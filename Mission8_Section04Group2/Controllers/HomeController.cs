using System.Diagnostics;
using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using Mission8_Section04Group2.Models;

namespace Mission8_Section04Group2.Controllers
{
    public class HomeController : Controller
    {
        private ManagementDbContext DbContext;

        public HomeController(ManagementDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult EditRecord()
        {
            return View();
        }

        public IActionResult QuadrantView()
            {
                // Use Include to eager load the Category for each Task
                var tasksWithCategories = DbContext.Tasks
                                                    .Include(t => t.Categories)  // Assuming Task has a navigation property called Category
                                                    .ToList();
                return View(tasksWithCategories); // Pass tasks with included categories to the view
            }

}