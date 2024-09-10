using System.ComponentModel.DataAnnotations;

namespace MyBudget.Models
{
    public class SavingsType
    {
        [Key]
        public int SavingsTypeID { get; set; }
        [Required]
        public string TypeName { get; set; }
        public string Unit { get; set; }
        public string Description { get; set; }
    }
}
