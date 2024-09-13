using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MyBudget.Data;
using MyBudget.Models;

namespace MyBudget.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly MyBudgetContext _context;

        public ExpensesController(MyBudgetContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var expenseHistory = _context.ExpenseHistory.ToList();
            return View(expenseHistory);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ExpenseHistory expenseHistory)
        {
            if (ModelState.IsValid)
            {
                _context.ExpenseHistory.Add(expenseHistory);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(expenseHistory);
        }

        public IActionResult Edit(int id)
        {
            var expenseHistory = _context.ExpenseHistory.Find(id);
            if (expenseHistory == null)
            {
                return NotFound();
            }
            return View(expenseHistory);
        }

        [HttpPost]
        public IActionResult Edit(int id, ExpenseHistory expenseHistory)
        {
            if (ModelState.IsValid)
            {
                _context.Update(expenseHistory);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(expenseHistory);
        }

        public IActionResult Delete(int id)
        {
            var expenseHistory = _context.ExpenseHistory.Find(id);
            if (expenseHistory == null)
            {
                return NotFound();
            }
            _context.ExpenseHistory.Remove(expenseHistory);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
