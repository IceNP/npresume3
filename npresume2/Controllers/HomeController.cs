using Microsoft.AspNetCore.Mvc;
using npresume2.Model;

namespace npresume2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
