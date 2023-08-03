using _0802pro1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _0802pro1.Controllers
{
    public class MesController : Controller
    {
        private readonly ILogger<MesController> _logger;

        public MesController(ILogger<MesController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}