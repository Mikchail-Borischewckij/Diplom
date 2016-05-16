using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeFinance.Data.Domain
{
    [Table("CostsPlaning")]
    public class CostsPlaning : Planing
    {
        [Required]
        [ForeignKey("CostsCategory")]
        [Column("CostsCategoryId")]
        public int CostsCategoryId { get; set; }
        
        public CostsCategory CostsCategory { get; set; }
    }
}
