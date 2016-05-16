using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeFinance.Data.Domain
{
    [Table("IncomeCategories")]
    public class IncomeCategory : Entity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
		public User User { get; set; }

		public List<IncomePlaning> IncomePlanings { get; set; }
    }
}
