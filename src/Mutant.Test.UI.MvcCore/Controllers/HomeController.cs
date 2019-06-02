using Microsoft.AspNetCore.Mvc;

namespace PlaySports.UI.MvcCore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }
    }
}
