using System.ComponentModel.DataAnnotations;

namespace MyBudget.Models
{
    public class IncomeCategory
    {
        [Key]
        public int IncomeCategoryID { get; set; }
        [Required]
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }
}
