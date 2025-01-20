using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Yogagym.Models;
using Yogagym.Services;

namespace Yogagym.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public readonly IPagesViewModel _pagesViewModel;

        private ViewModel GetPagesViewModel()
        {
            return _pagesViewModel.GetPagesViewModel();

        }


        public HomeController(ILogger<HomeController> logger, IPagesViewModel pagesViewModel)
        {
            _logger = logger;
            _pagesViewModel = pagesViewModel;
        }

        public IActionResult Index()
        {
            return View(GetPagesViewModel());
            
        }

        public IActionResult MemberHome()
        {
            return View();
        }

		public IActionResult AboutUs()
		{
			return View(GetPagesViewModel());
		}

        public IActionResult ContactUs()
        {
            return View(GetPagesViewModel());
        }

        public IActionResult Footer()
        {
            return View(GetPagesViewModel());
        }

        public IActionResult Header()
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
