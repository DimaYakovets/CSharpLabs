using Lab7.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Lab7.Controllers
{
    public sealed class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}