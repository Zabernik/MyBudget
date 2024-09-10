using Microsoft.AspNetCore.Mvc;

namespace MyBudget.Controllers
{
    public class AccountsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
