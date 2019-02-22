using Microsoft.AspNetCore.Mvc;

namespace $safeprojectname$.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return File("~/index.html", "text/html");
        }
    }
}