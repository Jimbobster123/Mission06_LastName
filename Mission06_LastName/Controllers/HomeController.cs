using Microsoft.AspNetCore.Mvc;

// HomeController.cs
// Handles general site pages such as:
// - Home page
// - Get to Know Joel page

namespace Mission06_LastName.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetToKnowJoel()
        {
            return View();
        }
    }
}
