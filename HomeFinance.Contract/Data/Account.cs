using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace HomeFinance.Contract.Data
{
    [DataContract]
    public class Account
    {
        public Account(int id, string name, double amountMoney, DateTime createdDate, int userId, int currencyId,
            Currency currency,
            List<Income> incomes,List<Cost> consumptions)
        {
            Id = id;
            Name = name;
            AmountMoney = amountMoney;
            CreatedDate = createdDate;
            UserId = userId;
            CurrencyId = currencyId;
            Currency = currency;
            Incomes = incomes;
            Сonsumptions = consumptions;
        }

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public double AmountMoney { get; set; }

        [DataMember]
        public DateTime CreatedDate { get; set; }

        [DataMember]
        public int UserId { get; set; }

        [DataMember]
        public int CurrencyId { get; set; }

        [DataMember]
        public Currency Currency { get; set; }

        [DataMember]
        public List<Income> Incomes { get; set; }

        [DataMember]
        public List<Cost> Сonsumptions { get; set; }
    }
}
