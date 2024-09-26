using System.Linq;
using System.Security.Principal;
using Microsoft.AspNetCore.Mvc;
using MyBudget.Data;
using MyBudget.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MyBudget.Controllers
{
    public class DepositsController : Controller
    {
        private readonly MyBudgetContext _context;

        public DepositsController(MyBudgetContext context)
        {
            _context = context;
        }

        // Akcja wyświetlająca listę kont
        public IActionResult Index()
        {
            Console.WriteLine("Test DUPA!!!!!");
            var deposits = _context.Deposit.ToList();
            return View(deposits);
        }

        // Akcja wyświetlająca szczegóły konta
        public IActionResult Details(int id)
        {
            var deposit = _context.Deposit.Find(id);
            if (deposit == null)
            {
                return NotFound();
            }
            return View(deposit);
        }

        // Akcja do tworzenia nowego konta
        public IActionResult Create()
        {
            Console.WriteLine("Test DUPA!!");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Deposit deposit)
        {
            if (ModelState.IsValid)
            {
                deposit.CreatedDate = DateTime.Now;
                deposit.LastUpdatedDate = DateTime.Now;
                _context.Deposit.Add(deposit);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
            }
            return View(deposit);
        }

        // Akcja do edytowania konta
        public IActionResult Edit(int id)
        {
            var deposit = _context.Deposit.Find(id);
            if (deposit == null)
            {
                return NotFound();
            }
            return View(deposit);
        }

        [HttpPost]
        public IActionResult Edit(int id, Deposit deposit)
        {
            if (ModelState.IsValid)
            {
                _context.Update(deposit);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(deposit);
        }

        // Akcja do usunięcia konta
        public IActionResult Delete(int id)
        {
            var deposit = _context.Deposit.Find(id);
            if (deposit == null)
            {
                return NotFound();
            }
            return View(deposit);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var deposit = _context.Deposit.Find(id);
            if (deposit == null)
            {
                return NotFound();
            }
            _context.Deposit.Remove(deposit);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
