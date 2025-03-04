using DecorationSystem.Filter;
using Microsoft.AspNetCore.Mvc;

namespace DecorationSystem.Controllers
{
    public class HomeController : Controller
    {
        [LoginFilter]
        public IActionResult Index()
        {
        
            return View();
        }

        public IActionResult WelcomeView()
        {
            return View();
        }
    }
}
