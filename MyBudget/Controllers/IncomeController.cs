using Microsoft.AspNetCore.Mvc;

namespace MyBudget.Controllers
{
    public class IncomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
