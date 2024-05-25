using Microsoft.AspNetCore.Mvc;
using QLY_HOCSINH.Models;
using System.Diagnostics;

namespace QLY_HOCSINH.Controllers
{
    public class HomeController : Controller
    {
        private readonly QlyHocSinhContext _context;
        public HomeController(QlyHocSinhContext context)
        {
            _context = context;
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
