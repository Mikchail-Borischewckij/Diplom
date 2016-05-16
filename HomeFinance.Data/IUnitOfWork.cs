using System;
using HomeFinance.Data.Repositories;

namespace HomeFinance.Data
{
    public interface IUnitOfWork : Core.IUnitOfWork, IDisposable
    {
        ITokenCollections Tokens { get; }
        IUsersCollections Users { get; }
        IAccountsCollections Accounts { get; }
        ICurrencyCollections Currencys { get; }
        ICostsCollections Costses { get; }
        IIncomeCollections Incomes { get; }
        IIncomeCategoriesCollections IncomeCategories { get; }
        ICostsCategoryCollections CostsCategories { get; }
        IIncomePlaningCollections IncomesPlaning { get; }
        ICostsPlaningCollections CostsPlaning { get; }
    }
}
