﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBudget.Models
{
    public class IncomeHistory
    {
        [Key]
        public int IncomeHistoryID { get; set; }
        [ForeignKey("AccountBalance")]
        public int AccountBalanceID { get; set; }
        [ForeignKey("IncomeCategory")]
        public int IncomeCategoryID { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public virtual AccountBalance AccountBalance { get; set; }
        public virtual IncomeCategory IncomeCategory { get; set; }
    }
}
