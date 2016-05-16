using System;
using System.Runtime.Serialization;

namespace HomeFinance.Contract.Data
{
    [DataContract]
    public class TransactionPlaning
    {
        public TransactionPlaning(int id, double amount, DateTime date, int accountId, int categoryId)
        {
            Id = id;
            Amount = amount;
            Date = date;
            CategoryId = categoryId;
            AccountId = accountId;
        }

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public double Amount { get; set; }

        [DataMember]
        public int AccountId { get; set; }

        [DataMember]
        public int CategoryId { get; set; }

        [DataMember]
        public DateTime Date { get; set; }
    }
}
