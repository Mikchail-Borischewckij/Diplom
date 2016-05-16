using HomeFinance.Core.Helpers;
using HomeFinance.Data.Domain;

namespace HomeFinance.Services.Impl
{
    internal static class EntitiesExtensions
    {
        public static void CopyFromContract(this User target, Contract.Authorization.User source)
        {
            target.Name = source.Name;
            target.Email = source.Email;
            target.Password = CryptographyPasswordHelper.Encrypt(source.Password);
        }

        public static void CopyFromContract(this IncomeCategory target, Contract.Data.IncomeCategory source)
        {
            target.Name = source.Name;
            target.UserId = source.UserId;
        }

        public static void CopyFromContract(this CostsPlaning target, Contract.Data.CostsPlaning source)
        {
            target.Amount = source.Amount;
            target.Date = source.Date;
            target.CostsCategoryId = source.CategoryId;
            target.AccountId = source.AccountId;
        }

        public static void CopyFromContract(this IncomePlaning target, Contract.Data.IncomePlaning source)
        {
            target.Amount = source.Amount;
            target.Date = source.Date;
			target.IncomeCategoryId = source.CategoryId;
			target.AccountId = source.AccountId;
        }

        public static void CopyFromContract(this CostsCategory target, Contract.Data.CostsCategory source)
        {
            target.Name = source.Name;
            target.UserId = source.UserId;
        }

        public static void CopyFromContract(this Account target, Contract.Data.Account source)
        {
            target.Name = source.Name;
            target.AmountMoney = source.AmountMoney;
            target.CreatedDate = source.CreatedDate;
            target.CurrencyId = source.CurrencyId;
            target.UserId = source.UserId;
        }

        public static void CopyFromContract(this Income target, Contract.Data.Income source)
        {
            target.Amount = source.Amount;
            target.Description = source.Description;
            target.UpdatedDate = source.UpdatedDate;
            target.TransactionType = (int)source.TransactionType;
            target.AccountId = source.AccountId;
            target.IncomeCategoryId = source.CategoryId;
        }

        public static void CopyFromContract(this Cost target, Contract.Data.Cost source)
        {
            target.Amount = source.Amount;
            target.Description = source.Description;
            target.UpdatedDate = source.UpdatedDate;
            target.TransactionType = (int)source.TransactionType;
            target.AccountId = source.AccountId;
            target.CostCategoryId = source.CategoryId;
        }

        public static void CopyFromContract(this Token target, Contract.Authorization.Token source)
        {
            target.AuthToken = source.AuthToken;
            target.ExpiresOn = source.ExpiresOn;
            target.IssuedOn = source.IssuedOn;
            target.UserId = source.UserId;
        }

        public static void CopyFromContract(this Currency target, Contract.Data.Currency source)
        {
            target.Name = source.Name;
        }
    }
}
