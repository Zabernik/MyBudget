using Microsoft.AspNetCore.Mvc;

namespace MyBudget.Controllers
{
    public class ExpensesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
