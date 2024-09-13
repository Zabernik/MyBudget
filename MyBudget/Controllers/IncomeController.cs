using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MyBudget.Data;
using MyBudget.Models;

namespace MyBudget.Controllers
{
    public class IncomeController : Controller
    {
        private readonly MyBudgetContext _context;

        public IncomeController(MyBudgetContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var incomeHistory = _context.IncomeHistory.ToList();
            return View(incomeHistory);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(IncomeHistory incomeHistory)
        {
            if (ModelState.IsValid)
            {
                _context.IncomeHistory.Add(incomeHistory);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(incomeHistory);
        }

        public IActionResult Edit(int id)
        {
            var incomeHistory = _context.IncomeHistory.Find(id);
            if (incomeHistory == null)
            {
                return NotFound();
            }
            return View(incomeHistory);
        }

        [HttpPost]
        public IActionResult Edit(int id, IncomeHistory incomeHistory)
        {
            if (ModelState.IsValid)
            {
                _context.Update(incomeHistory);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(incomeHistory);
        }

        public IActionResult Delete(int id)
        {
            var incomeHistory = _context.IncomeHistory.Find(id);
            if (incomeHistory == null)
            {
                return NotFound();
            }
            _context.IncomeHistory.Remove(incomeHistory);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
