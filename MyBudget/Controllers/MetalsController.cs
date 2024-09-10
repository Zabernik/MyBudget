using Microsoft.AspNetCore.Mvc;

namespace MyBudget.Controllers
{
    public class MetalsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
