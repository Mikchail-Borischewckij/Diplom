using System;
using System.Collections.Generic;
using System.Linq;
using HomeFinance.Contract;
using HomeFinance.Contract.Authorization;
using HomeFinance.Contract.Data;

namespace HomeFinance.Services.Impl
{
    internal static class EntitiesConverter
    {
        public static User ToInternalContract(Data.Domain.User item)
        {
            return new User(item.Id,item.Name,item.Email,item.Password);
        }

        public static UserInfo ToContract(Data.Domain.User item)
        {
            return new UserInfo(item.Id, item.Name, item.Email);
        }

        public static IncomeCategory ToContract(Data.Domain.IncomeCategory item)
        {
            return new IncomeCategory(item.Id, item.Name,item.UserId);
        }

        public static CostsCategory ToContract(Data.Domain.CostsCategory item)
        {
            return new CostsCategory(item.Id, item.Name, item.UserId);
        }

        public static Currency ToContract(Data.Domain.Currency item)
        {
            return  new Currency(item.Id,item.Name);
        }

        public static Account ToContract(Data.Domain.Account item)
        {
            Currency currency = ToContract(item.Currency);
            List<Income> incomes = item.Incomes != null ? item.Incomes.Select(ToContract).ToList() : new List<Income>();
            List<Cost> consumptions = item.Incomes != null ? item.Сonsumptions.Select(ToContract).ToList() : new List<Cost>();
            return new Account(item.Id, item.Name, item.AmountMoney, item.CreatedDate, item.UserId, item.CurrencyId, currency, incomes, consumptions);
        }

        public static Token ToInternalContract(Data.Domain.Token item)
        {
            return new Token(item.Id,item.UserId,item.AuthToken,item.IssuedOn,item.ExpiresOn);
        }

        public static Income ToContract(Data.Domain.Income item)
        {
            return new Income(item.Id, item.Amount, item.Description, item.CreatedDate, item.UpdatedDate, ToContract(item.TransactionType),
                item.AccountId,item.IncomeCategoryId);
        }

        public static Cost ToContract(Data.Domain.Cost item)
        {
            return new Cost(item.Id, item.Amount, item.Description, item.CreatedDate,item.UpdatedDate, ToContract(item.TransactionType),
                item.AccountId,item.CostCategoryId);
        }

        public static TransactionType ToContract(int transactionType)
        {
            TransactionType result;
            return Enum.TryParse(transactionType.ToString(), out result) ? result : TransactionType.None;
        }

        public static IncomePlaning ToContract(Data.Domain.IncomePlaning incomePlaning)
        {
            return new IncomePlaning(incomePlaning.Id, incomePlaning.Amount,incomePlaning.Date,incomePlaning.AccountId,incomePlaning.IncomeCategoryId);
        }

        public static CostsPlaning ToContract(Data.Domain.CostsPlaning costsPlaning)
        {
            return new CostsPlaning(costsPlaning.Id,costsPlaning.Amount,costsPlaning.Date,costsPlaning.AccountId,costsPlaning.CostsCategoryId);
        }
    }
}
