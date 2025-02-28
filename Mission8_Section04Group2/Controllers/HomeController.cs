using System.Diagnostics;
using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission8_Section04Group2.Models;
using static System.Net.Mime.MediaTypeNames;

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

        [HttpGet]
        public IActionResult TaskApplication()
        {
            ViewBag.Categories = _repo.Categories
                .OrderBy(x => x.CategoryName).ToList();

            return View("EditRecord", new Goal());
        }

        [HttpPost]
        public IActionResult TaskApplication(Goal response)
        {
            if (ModelState.IsValid)
            {
                _repo.AddGoal(response);
            }


            return Redirect("QuadrantView");

        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _repo.Goals
                .Single(x => x.GoalId == id);

            return View(recordToDelete);
        }

        [HttpPost]
        public IActionResult Delete(Goal application)
        {
            _repo.DeleteGoal(application);

            return RedirectToAction("QuadrantView");
        }

        public IActionResult EditRecord(int id)
        {
            var recordToEdit = _repo.Goals
                .Single(x => x.GoalId == id);

            ViewBag.Majors = _repo.Categories
                .OrderBy(x => x.CategoryName).ToList();

            return View("EditRecord", recordToEdit);
        }

        [HttpPost]
        public IActionResult EditRecord(Goal updatedInfo)
        {
            _repo.UpdateGoal(updatedInfo);
            return RedirectToAction("QuadrantView");
        }

        public IActionResult QuadrantView()
        {
            // Use Include to eager load the Category for each Goal
            var goalsWithCategories = _repo.Goals
                                            .AsQueryable()
                                            .Include(t => t.Category)  // Assuming Goal has a navigation property called Category
                                            .ToList();
            return View(goalsWithCategories); // Pass goals with included categories to the view
        }

    }
}