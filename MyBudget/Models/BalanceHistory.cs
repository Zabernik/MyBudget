using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBudget.Models
{
    public class BalanceHistory
    {
        [Key]
        public int BalanceHistoryID { get; set; }
        [ForeignKey("AccountBalance")]
        public int AccountBalanceID { get; set; }
        public decimal Balance { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }

        public virtual AccountBalance AccountBalance { get; set; }
    }
}
