using Microsoft.AspNetCore.Mvc;

namespace MyStat.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
