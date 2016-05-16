using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeFinance.Data.Domain
{
    [Table("Income")]
    public class Income : Entity
    {
        public double Amount { get; set; }
        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public int TransactionType { get; set; }

        [Required]
        public int AccountId { get; set; }

        public int IncomeCategoryId { get; set; }

        [ForeignKey("IncomeCategoryId")]
        public IncomeCategory IncomeCategory { get; set; }

        [ForeignKey("AccountId")]
        public Account Account { get; set; }
    }
}
