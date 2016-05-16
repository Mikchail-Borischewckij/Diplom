using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeFinance.Data.Domain
{
    public class Planing : Entity
    {
        [Required]
        [Column("Amount")]
        public double Amount { get; set; }

        [Required]
        [Column("Date")]
        public DateTime Date { get; set; }

        [Required]
        [ForeignKey("Account")]
        [Column("AccountId")]
        public int AccountId { get; set; }

        public Account Account { get; set; }
    }
}
