using System.ComponentModel.DataAnnotations.Schema;

namespace HomeFinance.Data.Domain
{
    [Table("Currency")]
    public class Currency : Entity
    {
        public string Name { get; set; }
    }
}
