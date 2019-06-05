using Microsoft.AspNetCore.Mvc;

namespace PlaySports.Controllers
{
    [Route("teste")]
    public class TesteController : Controller
    {
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
    }
}