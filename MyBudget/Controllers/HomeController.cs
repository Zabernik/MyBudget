using Microsoft.AspNetCore.Mvc;
using MyBudget.Data; // Namespace twojego kontekstu bazy danych
using MyBudget.Models;
using System.Diagnostics;
using System.Linq;

namespace MyBudget.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MyBudgetContext _context; // Dodaj kontekst bazy danych

        // Zmodyfikowany konstruktor przyjmuj¹cy równie¿ kontekst bazy danych
        public HomeController(ILogger<HomeController> logger, MyBudgetContext context)
        {
            _logger = logger;
            _context = context; // Inicjalizujemy kontekst
        }

        // Pobierz listê depozytów z bazy danych
        public IActionResult Index()
        {
            // Pobieramy listê depozytów z bazy danych za pomoc¹ Entity Framework
            var deposits = _context.Deposit.ToList();

            // Przekazujemy listê depozytów do widoku
            return View(deposits);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
