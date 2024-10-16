﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBudget.Models
{
    public class SavingsHistory
    {
        [Key]
        public int SavingsHistoryID { get; set; }
        [ForeignKey("Deposit")]
        public int DepositID { get; set; }
        [ForeignKey("SavingsType")]
        public int SavingsTypeID { get; set; }
        public decimal Amount { get; set; }
        public decimal Value { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }

        public virtual Deposit Deposit { get; set; }
        public virtual SavingsType SavingsType { get; set; }
    }
}
