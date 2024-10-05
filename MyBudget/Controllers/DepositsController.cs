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

        public IActionResult Index()
        {
            Console.WriteLine("Test DUPA!!!!!");
            var deposits = _context.Deposit.ToList();
            return View(deposits);
        }

        public IActionResult Details(int id)
        {
            var deposit = _context.Deposit.Find(id);
            if (deposit == null)
            {
                return NotFound();
            }
            return View(deposit);
        }

        public IActionResult Create()
        {
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

        public IActionResult Edit(int id)
        {
            var deposit = _context.Deposit.Find(id);
            Console.WriteLine(deposit.DepositID);
            Console.WriteLine(deposit.Currency);
            Console.WriteLine(deposit.DepositName);
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
                var existingDeposit = _context.Deposit.Find(id);

                if (existingDeposit == null)
                {
                    return NotFound();
                }

                existingDeposit.DepositName = deposit.DepositName;

                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(deposit);
        }

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

        public IActionResult UpdateBalance(int id)
        {
            var deposit = _context.Deposit.Find(id);
            if (deposit == null)
            {
                return NotFound();
            }
            return View(deposit);
        }

        [HttpPost]
        public IActionResult UpdateBalance(int id, Deposit deposit)
        {
            if (ModelState.IsValid)
            {
                DepositHistory newDepositHistory = new DepositHistory();
                var existingDeposit = _context.Deposit.Find(id);

                if (existingDeposit == null)
                {
                    return NotFound();
                }

                var diffDeposit = deposit.Balance - existingDeposit.Balance;
                existingDeposit.Balance = deposit.Balance;

                newDepositHistory.DepositID = existingDeposit.DepositID;
                newDepositHistory.Balance = diffDeposit;
                newDepositHistory.Date = DateTime.UtcNow;

                _context.DepositHistory.Add(newDepositHistory);

                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(deposit);
        }
    }
}
