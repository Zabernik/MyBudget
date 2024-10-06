using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace MyBudget.Models
{
    public class DepositHistory
    {
        [Key]
        public int DepositHistoryID { get; set; }
        [ForeignKey("Deposit")]
        public int DepositID { get; set; }
        public decimal Difference { get; set; }
        public decimal PreviousDeposit { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; } = "";

        public virtual Deposit Deposit { get; set; }
    }
}
