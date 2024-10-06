using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyBudget.Data;
using MyBudget.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MyBudget.Controllers
{
    public class DepositHistoryController : Controller
    {
        private readonly MyBudgetContext _context;

        public DepositHistoryController(MyBudgetContext context)
        {
            _context = context;
        }

        // Akcja do wyświetlania listy depozytów
        public async Task<IActionResult> Index()
        {
            var deposits = await _context.Deposit.ToListAsync();
            return View(deposits);
        }

        // Akcja do pobierania historii wybranego depozytu (AJAX)
        [HttpGet]
        public async Task<IActionResult> GetDepositHistory(int depositId)
        {
            // Logowanie ID dla testów
            Console.WriteLine("Deposit ID: " + depositId);

            var history = await _context.DepositHistory
                .Where(h => h.DepositID == depositId)
                .OrderByDescending(h => h.Date)
                .Take(6)  // Pobieramy ostatnie 6 rekordów
                .ToListAsync();

            if (history == null)
            {
                return NotFound();
            }

            return PartialView("~/Views/DepositHistory/_DepositHistoryPartial.cshtml", history);
        }
    }
}
