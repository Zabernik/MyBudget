using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyBudget.Models
{
    public class Deposit
    {
        [Key]
        public int DepositID { get; set; }
        [Required]
        public string DepositName { get; set; }
        public decimal Balance { get; set; }
        [Required]
        public string Currency { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }

        public ICollection<DepositHistory> DepositHistory { get; set; }
        public ICollection<IncomeHistory> IncomeHistories { get; set; }
        public ICollection<ExpenseHistory> ExpenseHistories { get; set; }
        public ICollection<SavingsHistory> SavingsHistories { get; set; }
    }
}
