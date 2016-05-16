using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeFinance.Data.Domain
{
    [Table("IncomePlaning")]
    public class IncomePlaning : Planing
    {
		[Required]
		[ForeignKey("IncomeCategory")]
		[Column("IncomeCategoryId")]
		public int IncomeCategoryId { get; set; }

		public IncomeCategory IncomeCategory { get; set; }
    }
}
