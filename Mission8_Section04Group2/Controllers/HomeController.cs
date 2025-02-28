using System.Diagnostics;
using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission8_Section04Group2.Models;

namespace Mission8_Section04Group2.Controllers
{
    public class HomeController : Controller
    {
        private IGoalRepository _repo;

        public HomeController(IGoalRepository temp)
        {
            _repo = temp;
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
            var tasksWithCategories = _repo.Tasks //I CHANGED THIS TO _repo instead of DbContext because the variable changed with repository
                                                .Include(t => t.Category)  // Assuming Task has a navigation property called Category
                                                .ToList();
            return View(tasksWithCategories); // Pass tasks with included categories to the view
        }

        //To save changes with repo there needs to be another class here. Picture on Madi's phone 
       
    }
}