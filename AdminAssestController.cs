using Microsoft.AspNetCore.Mvc;

namespace Yogagym.Controllers
{
    public class AdminAssestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
