﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBudget.Models
{
    public class Deposit
    {
        [Key]
        public int DepositID { get; set; }
        [Required]
        public string DepositName { get; set; }
        [Required]
        public decimal Balance { get; set; }
        [Required]
        public string Currency { get; set; } = "PLN";
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }

        public ICollection<DepositHistory> DepositHistory { get; set; } = new List<DepositHistory>();
        public ICollection<SavingsHistory> SavingsHistories { get; set; } = new List<SavingsHistory>();
    }
}
