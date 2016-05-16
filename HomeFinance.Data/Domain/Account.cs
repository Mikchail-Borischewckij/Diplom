using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeFinance.Data.Domain
{
    [Table("Account")]
    public class Account : Entity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public double AmountMoney { get; set; }

        public DateTime CreatedDate { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int CurrencyId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        [ForeignKey("CurrencyId")]
        public Currency Currency { get; set; }

        public List<Income> Incomes { get; set; }
        public List<Cost> Сonsumptions { get; set; }
		public List<IncomePlaning> IncomePlanings { get; set; }
    }
}
