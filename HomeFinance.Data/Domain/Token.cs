using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeFinance.Data.Domain
{
    [Table("Tokens")]
    public class Token : Entity
    {
        [Required]
        [Column("UserId")]
        public int UserId { get; set; }

        public string AuthToken { get; set; }
        public DateTime IssuedOn { get; set; }
        public DateTime ExpiresOn { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
