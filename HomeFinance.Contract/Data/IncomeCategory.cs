using System.Runtime.Serialization;

namespace HomeFinance.Contract.Data
{
    [DataContract]
    public class IncomeCategory
    {
        public IncomeCategory(int id, string name, int userId)
        {
            Id = id;
            Name = name;
            UserId = userId;
        }

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int UserId { get; set; }
    }
}
