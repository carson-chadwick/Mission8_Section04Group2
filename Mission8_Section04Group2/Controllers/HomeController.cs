using System.Diagnostics;
using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using Mission8_Section04Group2.Models;

namespace Mission8_Section04Group2.Controllers
{
    public class HomeController : Controller
    {

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
            return View();
        }
    }
}