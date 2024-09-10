using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyBudget.Models
{
    public class AccountBalance
    {
        [Key]
        public int AccountBalanceID { get; set; }
        [Required]
        public string AccountName { get; set; }
        public decimal Balance { get; set; }
        [Required]
        public string Currency { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public ICollection<BalanceHistory> BalanceHistories { get; set; }
        public ICollection<IncomeHistory> IncomeHistories { get; set; }
        public ICollection<ExpenseHistory> ExpenseHistories { get; set; }
        public ICollection<SavingsHistory> SavingsHistories { get; set; }
    }
}
