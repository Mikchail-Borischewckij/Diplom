using System;
using System.Data;

namespace HomeFinance.Core
{
    public interface IUnitOfWork : IDisposable
    {
        void BeginTransaction(IsolationLevel isolationLevel);
        void Rollback();
        void Commit();
        /// <summary>
        /// Saves all changes made in this unit of work.
        /// </summary>
        int SaveChanges();
    }
}
