using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeFinance.Data.Domain
{
    [Table("Users")]
    public class User : Entity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public List<IncomeCategory> IncomeCategories { get; set; }
        public List<CostsCategory> CostsCategories { get; set; }
    }
}
