using Microsoft.AspNetCore.Mvc;

namespace EmployersWebApplication.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
