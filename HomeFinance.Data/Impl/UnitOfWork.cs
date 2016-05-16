using System;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using HomeFinance.Data.Repositories;
using HomeFinance.Data.Repositories.Impl;

namespace HomeFinance.Data.Impl
{
    public class UnitOfWork: IUnitOfWork
    {
        private DbContext _dataContext;
        private ObjectContext _objectContext;
        private DbTransaction _transaction;
        private bool _disposed;
        private readonly Lazy<IUsersCollections> _lazyUsersRepository;
        private readonly Lazy<ITokenCollections> _lazyTokensRepository;
        private readonly Lazy<IAccountsCollections> _lazyAccountsRepository;
        private readonly Lazy<ICurrencyCollections> _lazyCurrencyRepository;
        private readonly Lazy<ICostsCollections> _lazyСonsumptionRepository;
        private readonly Lazy<IIncomeCollections> _lazyIncomeRepository;
        private readonly Lazy<IIncomeCategoriesCollections> _lazyIncomeCategoriesRepository;
        private readonly Lazy<ICostsCategoryCollections> _lazyCostsCategoryRepository;
        private readonly Lazy<IIncomePlaningCollections> _lazyIncomePlaningRepository;
        private readonly Lazy<ICostsPlaningCollections> _lazyCostsPlaningRepository;

        public UnitOfWork(DatabaseContext databaseContext)
        {
            _dataContext = databaseContext;
            _lazyUsersRepository = new Lazy<IUsersCollections>(() => new UsersRepository(_dataContext));
            _lazyTokensRepository = new Lazy<ITokenCollections>(() => new TokensRepository(_dataContext));
            _lazyAccountsRepository = new Lazy<IAccountsCollections>(() => new AccountsRepository(_dataContext));
            _lazyCurrencyRepository = new Lazy<ICurrencyCollections>(() => new CurrencyRepository(_dataContext));
            _lazyСonsumptionRepository = new Lazy<ICostsCollections>(() => new CostsRepository(_dataContext));
            _lazyIncomeRepository = new Lazy<IIncomeCollections>(() => new IncomeRepository(_dataContext));
            _lazyIncomeCategoriesRepository = new Lazy<IIncomeCategoriesCollections>(() => new IncomeCategoriesRepository(_dataContext));
            _lazyCostsCategoryRepository = new Lazy<ICostsCategoryCollections>(() => new CostsCategoryRepository(_dataContext));
            _lazyIncomePlaningRepository = new Lazy<IIncomePlaningCollections>(() => new IncomePlaningRepository(_dataContext));
            _lazyCostsPlaningRepository = new Lazy<ICostsPlaningCollections>(() => new CostsPlaningRepository(_dataContext));
        }

        public ITokenCollections Tokens
        {
            get { return _lazyTokensRepository.Value; }
        }

        public IUsersCollections Users
        {
            get { return _lazyUsersRepository.Value; }
        }

        public IAccountsCollections Accounts
        {
            get { return _lazyAccountsRepository.Value; }
        }

        public ICurrencyCollections Currencys
        {
            get { return _lazyCurrencyRepository.Value; }
        }

        public ICostsCollections Costses
        {
            get { return _lazyСonsumptionRepository.Value; }
        }

        public IIncomeCollections Incomes
        {
            get { return _lazyIncomeRepository.Value; }
        }

        public IIncomeCategoriesCollections IncomeCategories
        {
            get { return _lazyIncomeCategoriesRepository.Value; }
        }

        public ICostsCategoryCollections CostsCategories
        {
            get { return _lazyCostsCategoryRepository.Value; }
        }

        public IIncomePlaningCollections IncomesPlaning
        {
             get { return _lazyIncomePlaningRepository.Value; }
        }

        public ICostsPlaningCollections CostsPlaning
        {
            get { return _lazyCostsPlaningRepository.Value; }
        }

        public int SaveChanges()
        {
            return _dataContext.SaveChanges();
        }

        public void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            _objectContext = ((IObjectContextAdapter)_dataContext).ObjectContext;
            if (_objectContext.Connection.State != ConnectionState.Open)
            {
                _objectContext.Connection.Open();
            }

            _transaction = _objectContext.Connection.BeginTransaction(isolationLevel);
        }

        public void Commit()
        {
            _transaction.Commit();
        }

        public void Rollback()
        {
            _transaction.Rollback();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {

			if (_disposed)
			{
				return;
			}
			_disposed = true;

			if (disposing)
			{
				// Free other managed objects that implement IDisposable only
				try
				{
					if (_objectContext != null && _objectContext.Connection.State == ConnectionState.Open)
					{
						_objectContext.Connection.Close();
					}
				}
				catch (ObjectDisposedException)
				{
					// Do nothing, the objectContext has already been disposed
				}

				//if (_dataContext != null)
				//{
				//	_dataContext.Dispose();
				//	_dataContext = null;
				//}
			}
        }
    }
}
