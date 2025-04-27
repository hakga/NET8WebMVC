using Microsoft.AspNetCore.Mvc;
using NET8WebMVC.DB;
using NET8WebMVC.Domain.Repositories;
using NET8WebMVC.Models;
using System.Diagnostics;

namespace NET8WebMVC.Controllers {
    public class HomeController : Controller {
        private readonly SampleDbContext _context;
        private readonly ILogger<HomeController> _logger;
        private readonly ILoaderMembers _loaderMembers;

        public HomeController(ILogger<HomeController> logger, SampleDbContext context, ILoaderMembers loaderMembers) {
            _logger = logger;
            _context = context;
            _loaderMembers = loaderMembers;
        }

        public IActionResult Index() {
            return View();
        }

        public IActionResult Privacy() {
            return View();
        }

        public IActionResult Sample(int? id) {
            var member = _context.Members.FirstOrDefault();     // DB�R���e�L�X�g����DI�ȃf�[�^�ǂݏo��
            if (id != null) {
            member =_context.Members.FirstOrDefault(r => r.Id == id);
            }
            return View(member);
        }
        public IActionResult Samples() {
            _logger.LogInformation("LogInformation.");
            var members = _loaderMembers.Load();        // �ˑ��������ς݂̃f�[�^�ǂݏo��
            return View(members);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            _logger.LogCritical("LogCritical!!");
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
