using System;
using System.Runtime.Serialization;

namespace HomeFinance.Contract.Data
{
    [DataContract]
    public class Cost
    {
        public Cost(int id, double amount, string description, DateTime createdDate, DateTime? updatedDate, TransactionType transactionType, int accountId,int categoryId)
        {
            Id = id;
            Amount = amount;
            Description = description;
            CreatedDate = createdDate;
            UpdatedDate = updatedDate;
            TransactionType = transactionType;
            AccountId = accountId;
            CategoryId = categoryId;
        }

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public double Amount { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public DateTime CreatedDate { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public DateTime? UpdatedDate { get; set; }

        [DataMember]
        public TransactionType TransactionType { get; set; }

        [DataMember]
        public int AccountId { get; set; }

        [DataMember]
        public int CategoryId { get; set; }
    }
}
