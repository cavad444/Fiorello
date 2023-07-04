using Fiorello.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Fiorello.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public IActionResult Index()
        {
            return View();
        }

    }
}