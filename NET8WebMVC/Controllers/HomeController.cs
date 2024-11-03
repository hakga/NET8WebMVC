using Microsoft.AspNetCore.Mvc;
using NET8WebMVC.DB;
using NET8WebMVC.Models;
using System.Diagnostics;

namespace NET8WebMVC.Controllers {
    public class HomeController : Controller {
        private readonly SampleDbContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, SampleDbContext context) {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index() {
            return View();
        }

        public IActionResult Privacy() {
            return View();
        }

        public IActionResult Sample(int id) {
            var member = _context.Members.FirstOrDefault(r => r.Id == id);
            return View(member);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
