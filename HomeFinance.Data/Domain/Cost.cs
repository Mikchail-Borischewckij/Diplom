using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeFinance.Data.Domain
{
    [Table("Costs")]
    public class Cost : Entity
    {
        public double Amount { get; set; }
        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public int TransactionType { get; set; }

        [Required]
        public int AccountId { get; set; }

        public int CostCategoryId { get; set; }

        [ForeignKey("CostCategoryId")]
        public CostsCategory CostCategory { get; set; }

        [ForeignKey("AccountId")]
        public Account Account { get; set; }


    }
}
