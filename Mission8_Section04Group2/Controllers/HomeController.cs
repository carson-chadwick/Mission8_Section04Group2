using System.Diagnostics;
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

    }
}
