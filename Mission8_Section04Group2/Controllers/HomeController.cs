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
        private TaskFormContext DbContext;

        public HomeController(TaskFormContext dbContext)
        {
            DbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult TaskApplication()
        {
            ViewBag.Categories = DbContext.Categories
                .OrderBy(x => x.CategoryName).ToList();

            return View("EditRecord", new Goal());
        }

        [HttpPost]
        public IActionResult TaskApplication(Goal response)
        {
            if (ModelState.IsValid)
            {
                DbContext.Tasks.Add(response); //add record to the database
                DbContext.SaveChanges();
                return View("QuadrantView", response);
            }
            else
            {
                ViewBag.Categories = DbContext.Categories
                .OrderBy(x => x.CategoryName).ToList();

                return View("EditRecord", response);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = DbContext.Tasks
                .Single(x => x.TaskId == id);

            return View(recordToDelete);
        }

        [HttpPost]
        public IActionResult Delete(Goal application)
        {
            DbContext.Tasks.Remove(application);
            DbContext.SaveChanges();

            return RedirectToAction("QuadrantView");
        }

        public IActionResult EditRecord(int id)
        {
            var recordToEdit = DbContext.Tasks
                .Single(x => x.TaskId == id);

            ViewBag.Majors = DbContext.Categories
                .OrderBy(x => x.CategoryName).ToList();

            return View("EditRecord", recordToEdit);
        }

        [HttpPost]
        public IActionResult EditRecord(Goal updatedInfo)
        {
            DbContext.Update(updatedInfo);
            DbContext.SaveChanges();
            return RedirectToAction("QuadrantView");
        }

        public IActionResult QuadrantView()
        {
            // Use Include to eager load the Category for each Task
            var tasksWithCategories = DbContext.Tasks
                                                .Include(t => t.Category)  // Assuming Task has a navigation property called Category
                                                .ToList();
            return View(tasksWithCategories); // Pass tasks with included categories to the view
        }

    }
}