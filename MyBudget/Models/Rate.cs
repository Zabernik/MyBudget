using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBudget.Models
{
    public class Rate
    {
        [Key]
        public int RateID { get; set; }
        [ForeignKey("SavingsType")]
        public int SavingsTypeID { get; set; }
        public decimal RateValue { get; set; }
        public DateTime Date { get; set; }
        public string Currency { get; set; }
        public string Source { get; set; }

        public virtual SavingsType SavingsType { get; set; }
    }
}
