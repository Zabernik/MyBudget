using System.Diagnostics;
using System.Linq;
using System.Security.Principal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyBudget.Data;
using MyBudget.Models;
using Newtonsoft.Json;
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

                newDepositHistory.PreviousDeposit = existingDeposit.Balance;
                existingDeposit.Balance = deposit.Balance;

                newDepositHistory.DepositID = existingDeposit.DepositID;
                newDepositHistory.Difference = diffDeposit;
                newDepositHistory.Date = DateTime.UtcNow;

                _context.DepositHistory.Add(newDepositHistory);

                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(deposit);
        }

        public async Task<IActionResult> PrepareDepositData()
        {
            try
            {
                Console.WriteLine("[INFO] Pobieranie danych z bazy danych...");

                var depositData = await _context.Deposit
                    .Include(d => d.DepositHistory)
                    .Select(d => new
                    {
                        DepositName = d.DepositName,
                        Balance = d.Balance,
                        Currency = d.Currency,
                        Histories = d.DepositHistory
                            .OrderBy(h => h.Date)
                            .Select(h => new { h.Date, h.PreviousDeposit, h.Difference })
                    })
                    .ToListAsync();

                var jsonData = JsonConvert.SerializeObject(depositData);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Scripts", "deposit_data.json");

                Console.WriteLine($"[INFO] Zapisywanie danych do pliku JSON: {filePath}");
                System.IO.File.WriteAllText(filePath, jsonData);

                Console.WriteLine("[INFO] Dane zostały zapisane poprawnie.");
                return Ok("Data prepared for Python.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] Błąd podczas przygotowywania danych: {ex.Message}");
                return StatusCode(500, "Błąd podczas przygotowywania danych.");
            }
        }


        public IActionResult RunPythonScript()
        {
            try
            {
                string pythonScript = Path.Combine(Directory.GetCurrentDirectory(), "Scripts", "Script.py");
                Console.WriteLine($"[INFO] Uruchamianie skryptu Python: {pythonScript}");

                var psi = new ProcessStartInfo
                {
                    FileName = @"python",
                    Arguments = $"\"{pythonScript}\"",
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true
                };

                var process = Process.Start(psi);
                string output = process.StandardOutput.ReadToEnd();
                string errors = process.StandardError.ReadToEnd();
                process.WaitForExit();

                Console.WriteLine($"[INFO] Wynik skryptu Python: {output}");
                if (!string.IsNullOrWhiteSpace(errors))
                {
                    Console.WriteLine($"[ERROR] Błędy skryptu Python: {errors}");
                }

                return Ok("Python script executed, graphs generated.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] Błąd podczas uruchamiania skryptu: {ex.Message}");
                return StatusCode(500, "Błąd podczas uruchamiania skryptu.");
            }
        }




    }
}
