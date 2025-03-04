using Microsoft.AspNetCore.Mvc;

namespace DecorationSystem.Controllers
{
    public class RoleMenuController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
