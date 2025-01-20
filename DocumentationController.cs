using Microsoft.AspNetCore.Mvc;

namespace Yogagym.Controllers
{
    public class DocumentationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
