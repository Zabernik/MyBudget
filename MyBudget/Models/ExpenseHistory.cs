using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBudget.Models
{
    public class ExpenseHistory
    {
        [Key]
        public int ExpenseHistoryID { get; set; }
        [ForeignKey("Deposit")]
        public int DepositID { get; set; }
        public string Category { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }

        public virtual Deposit Deposit { get; set; }
    }
}
